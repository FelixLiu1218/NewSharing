using System;

namespace NewProject.Core
{
    public class FileLogger : ILogger
    {
        #region Public properties

        /// <summary>
        /// Write to log file path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// True: logs the current time with each message
        /// </summary>
        public bool LogTime { get; set; } = true;

        #endregion

        #region Constructor

        public FileLogger(string filePath)
        {
            //Set the fileproperty
            FilePath = filePath;
        }

        #endregion

        #region Logger Methods

        public void Log(string message, LogLevel level)
        {
            // Get current time
            var currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss");

            //prepend the time to the log
            var timeLogString = LogTime ? $"{currentTime}" : "";

            //Write the message to file
            IoC.File.WriteTexttoFile($"{timeLogString} {message}{Environment.NewLine}", FilePath, append: true);
        }

        #endregion

    }
}
