using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NewProject.Core
{
    public interface ITaskManager
    {
        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        //     object that represents that work.
        //
        // 參數:
        //   action:
        //     The work to execute asynchronously
        //
        // 傳回:
        //     A task that represents the work queued to execute in the ThreadPool.
        //
        // 例外狀況:
        //   T:System.ArgumentNullException:
        //     The action parameter was null.
        [MethodImpl(MethodImplOptions.NoInlining)]
        Task Run(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        //     object that represents that work. A cancellation token allows the work to be
        //     cancelled.
        //
        // 參數:
        //   action:
        //     The work to execute asynchronously
        //
        //   cancellationToken:
        //     A cancellation token that can be used to cancel the work
        //
        // 傳回:
        //     A task that represents the work queued to execute in the thread pool.
        //
        // 例外狀況:
        //   T:System.ArgumentNullException:
        //     The action parameter was null.
        //
        //   T:System.Threading.Tasks.TaskCanceledException:
        //     The task has been canceled.
        //
        //   T:System.ObjectDisposedException:
        //     The System.Threading.CancellationTokenSource associated with cancellationToken
        //     was disposed.
        [MethodImpl(MethodImplOptions.NoInlining)]
        Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task`1
        //     object that represents that work.
        //
        // 參數:
        //   function:
        //     The work to execute asynchronously.
        //
        // 類型參數:
        //   TResult:
        //     The return type of the task.
        //
        // 傳回:
        //     A task object that represents the work queued to execute in the thread pool.
        //
        // 例外狀況:
        //   T:System.ArgumentNullException:
        //     The function parameter is null.
        [MethodImpl(MethodImplOptions.NoInlining)]
        Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a Task(TResult)
        //     object that represents that work. A cancellation token allows the work to be
        //     cancelled.
        //
        // 參數:
        //   function:
        //     The work to execute asynchronously
        //
        //   cancellationToken:
        //     A cancellation token that should be used to cancel the work
        //
        // 類型參數:
        //   TResult:
        //     The result type of the task.
        //
        // 傳回:
        //     A Task(TResult) that represents the work queued to execute in the thread pool.
        //
        // 例外狀況:
        //   T:System.ArgumentNullException:
        //     The function parameter is null.
        //
        //   T:System.Threading.Tasks.TaskCanceledException:
        //     The task has been canceled.
        //
        //   T:System.ObjectDisposedException:
        //     The System.Threading.CancellationTokenSource associated with cancellationToken
        //     was disposed.
        [MethodImpl(MethodImplOptions.NoInlining)]
        Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a proxy for the
        //     task returned by function.
        //
        // 參數:
        //   function:
        //     The work to execute asynchronously
        //
        // 傳回:
        //     A task that represents a proxy for the task returned by function.
        //
        // 例外狀況:
        //   T:System.ArgumentNullException:
        //     The function parameter was null.
        Task Run(Func<Task> function, [CallerMemberName]string origin ="",[CallerFilePath]string filePath="",[CallerLineNumber]int lineNumber = 0);

        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a proxy for the
        //     task returned by function.
        //
        // 參數:
        //   function:
        //     The work to execute asynchronously.
        //
        //   cancellationToken:
        //     A cancellation token that should be used to cancel the work.
        //
        // 傳回:
        //     A task that represents a proxy for the task returned by function.
        //
        // 例外狀況:
        //   T:System.ArgumentNullException:
        //     The function parameter was null.
        //
        //   T:System.Threading.Tasks.TaskCanceledException:
        //     The task has been canceled.
        //
        //   T:System.ObjectDisposedException:
        //     The System.Threading.CancellationTokenSource associated with cancellationToken
        //     was disposed.
        Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a proxy for the
        //     Task(TResult) returned by function.
        //
        // 參數:
        //   function:
        //     The work to execute asynchronously
        //
        // 類型參數:
        //   TResult:
        //     The type of the result returned by the proxy task.
        //
        // 傳回:
        //     A Task(TResult) that represents a proxy for the Task(TResult) returned by function.
        //
        // 例外狀況:
        //   T:System.ArgumentNullException:
        //     The function parameter was null.
        Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a proxy for the
        //     Task(TResult) returned by function.
        //
        // 參數:
        //   function:
        //     The work to execute asynchronously
        //
        //   cancellationToken:
        //     A cancellation token that should be used to cancel the work
        //
        // 類型參數:
        //   TResult:
        //     The type of the result returned by the proxy task.
        //
        // 傳回:
        //     A Task(TResult) that represents a proxy for the Task(TResult) returned by function.
        //
        // 例外狀況:
        //   T:System.ArgumentNullException:
        //     The function parameter was null.
        //
        //   T:System.Threading.Tasks.TaskCanceledException:
        //     The task has been canceled.
        //
        //   T:System.ObjectDisposedException:
        //     The System.Threading.CancellationTokenSource associated with cancellationToken
        //     was disposed.

        Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Queues the specified work to run on the thread pool and returns a proxy for the
        /// task returned by function.
        /// </summary>
        /// <param name="function">The work to execute asynchronously</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line of code in the filename this message was logged from</param>
        /// <remarks>
        ///     The passed in Task cannot be awaited as it is to be run and forgotten.
        ///     Any errors thrown will get logged to the ILogger in the DI provider
        ///     and then swallowed and not re-thrown to the caller thread
        /// </remarks>
        /// <returns>A task that represents a proxy for the task returned by function.</returns>
        /// <exception cref="ArgumentNullException">The function parameter was null.</exception>
        void RunAndForget(Func<Task> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
        
    }
}
