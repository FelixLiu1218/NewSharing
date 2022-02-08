using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Core
{
    /// <summary>
    /// A logger that handle log message from Ilogfactory
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Handles the logged message being passed in
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        void Log(string message, LogFactoryLevel level);
    }
}
