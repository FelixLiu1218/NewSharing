using System;
using System.Runtime.CompilerServices;

namespace NewProject.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogFactory
    {
        #region Events

        /// <summary>
        /// Fires when a noe log arrives
        /// </summary>
        event Action<(String Message, LogLevel Level)> NewLog;

        #endregion

        #region Properties

        /// <summary>
        /// The level of logging to output
        /// </summary>
        LogOutputLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true,includes the origin of where the log message was logged from
        /// such as the class name,line number,and file name
        /// </summary>
        bool IncludeOriginDetails { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Add logger to this factory
        /// </summary>
        /// <param name="logger"></param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// Remove logger from this factory
        /// </summary>
        /// <param name="logger"></param>
        void RemoveLogger(ILogger logger);

        /// <summary>
        /// Logs the message to all loggers in this factory
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level">The level of the message</param>
        /// <param name="origin"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        void Log(string message, LogLevel level = LogLevel.Informative,[CallerMemberName]string origin ="",[CallerFilePath]string filePath ="",[CallerLineNumber]int lineNumber = 0);


        #endregion
    }
}
