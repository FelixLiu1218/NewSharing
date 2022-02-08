using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NewProject.Core
{
    /// <summary>
    /// Handles anything to do with Tasks
    /// </summary>
    public class TaskManager : ITaskManager
    {
        #region Task Methods

        public Task Run(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            //Try and run the task
            try
            {
                return Task.Run(action);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            //Try and run the task
            try
            {
                return Task.Run(action,cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            //Try and run the task
            try
            {
                return Task.Run(function,cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public async Task Run(Func<Task> function,[CallerMemberName]string orgin ="",[CallerFilePath] string filePath ="",[CallerLineNumber]int lineNumber = 0)
        {
            //Try and run the task
            try
            {
                await Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            //Try and run the task
            try
            {
                return Task.Run(function,cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            //Try and run the task
            try
            {
                return Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            //Try and run the task
            try
            {
                return Task.Run(function,cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        #endregion

        #region Private Helper Methods


        /// <summary>
        /// Logs the given error to the log factory
        /// </summary>
        /// <param name="ex">The exception to log</param>
        /// <param name="origin"> </param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        private void LogError(Exception ex, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            IoC.Logger.Log($"An unexpected error occurred running a ioc.task.run {ex.Message}", LogLevel.Debug,origin,filePath,lineNumber);
        }

        #endregion

    }
}
