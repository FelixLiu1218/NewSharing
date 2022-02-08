
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NewProject.Core
{
    public class DebugLogger : ILogger
    {
        public void Log(string message, LogLevel level)
        {
            var category = "";

            switch (level)
            {
                case LogLevel.Debug:
                    category = "information";
                    break;
                case LogLevel.Verbose:
                    category = "verbose";
                    break;
                case LogLevel.Warning:
                    category = "warning";
                    break;
                case LogLevel.Error:
                    category = "error";
                    break;
                case LogLevel.Success:
                    category = "-----";
                    break;
            }
            Debug.WriteLine(message,category);
        }
    }
}
