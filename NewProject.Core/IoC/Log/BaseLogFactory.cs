using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Runtime.CompilerServices;

namespace NewProject.Core
{
    /// <summary>
    /// Logs details about Console by default
    /// </summary>
    public class BaseLogFactory : ILogFactory
    {
        #region Protected Methods

        /// <summary>
        /// The list of loggers in this factory
        /// </summary>
        protected List<ILogger> _loggers = new List<ILogger>();

        /// <summary>
        /// A lock for the logger list to keep it thread-safe
        /// </summary>
        protected object _loggersLock = new object();

        #endregion

        #region Public properties

        /// <summary>
        /// The level of logging to output
        /// </summary>
        public LogFactoryLevel LogOutputLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// If true,includes the origin of where the log message was logged from
        /// such as the class name,line number,and file name
        /// </summary>
        public bool IncludeOriginDetails { get; set; } =true;

        #endregion

        #region Public Events

        /// <summary>
        /// Fires when a noe log arrives
        /// </summary>
        public event Action<(string Message, LogFactoryLevel Level)> NewLog = (details) => {};

        #endregion


        /// <summary>
        /// Add logger to this factory
        /// </summary>
        /// <param name="logger"></param>
        public void AddLogger(ILogger logger)
        {
            // Log the list so it is thread-safe
            lock (_loggersLock)
            {
                //if the logger doesn't exist
                if(!(_loggers.Contains(logger)))
                    //Add the logger to list
                    _loggers.Add(logger);
            }
        }

        /// <summary>
        /// Remove logger from this factory
        /// </summary>
        /// <param name="logger"></param>
        public void RemoveLogger(ILogger logger)
        {
            // Log the list so it is thread-safe
            lock (_loggersLock)
            {
                //if the logger doesn't exist
                if (_loggers.Contains(logger))
                    //Add the logger to list
                    _loggers.Remove(logger);
            }
        }

        /// <summary>
        /// Logs the message to all loggers in this factory
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level">The level of the message</param>
        /// <param name="origin"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public void Log(string message, 
            LogFactoryLevel level = LogFactoryLevel.Informative, 
            [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            //Where the log originated from
            if (IncludeOriginDetails)
                message = $"[{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}] {Environment.NewLine}{message} ";

            // Log to all loggers
            _loggers.ForEach(logger => logger.Log(message,level));

            //Inform listeners
            NewLog.Invoke((message,level));
        }
    }
}
