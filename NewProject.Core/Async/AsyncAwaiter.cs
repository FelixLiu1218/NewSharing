using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace NewProject.Core
{
    public static class AsyncAwaiter
    {
        #region Private Members

        private static SemaphoreSlim _selflock = new SemaphoreSlim(1,1);

        private static Dictionary<string, SemaphoreSlim> _semaphores = new Dictionary<string, SemaphoreSlim>();

        #endregion

        public static async Task<T> AwaitResultAsync<T>(string key, Func<Task<T>> task, int maxAccessCount = 1)
        {
            #region Create Semaphore

            await _selflock.WaitAsync();

            try
            {
                if (!_semaphores.ContainsKey(key))
                {
                    _semaphores.Add(key, new SemaphoreSlim(maxAccessCount, maxAccessCount));
                }
            }
            finally
            {
                _selflock.Release();
            }

            #endregion

            var semaphore = _semaphores[key];

            await semaphore.WaitAsync();

            try
            {
                return await task();
            }
            finally
            {
                semaphore.Release();
            }
        }

        public static async Task AwaitAsync(string key, Func<Task> task, int maxAccessCount = 1)
        {
            #region Create Semaphore

            await _selflock.WaitAsync();

            try
            {
                if (!_semaphores.ContainsKey(key))
                {
                    _semaphores.Add(key, new SemaphoreSlim(maxAccessCount, maxAccessCount));
                }
            }
            finally
            {
                _selflock.Release();
            }

            #endregion

            var semaphore = _semaphores[key];

            await semaphore.WaitAsync();

            try
            {
                await task();
            }
            catch (Exception ex)
            {
                var error = ex.Message;

                IoC.Logger.Log($"Crash in {nameof(AwaitAsync)}.{ex.Message}", LogLevel.Debug);

                Debugger.Break();

                throw;
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
