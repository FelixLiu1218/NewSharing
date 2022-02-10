using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.XPath;
using static NewProject.Core.CoreDI;

namespace NewProject.Core
{
    /// <summary>
    /// Handles reading/writing the file system
    /// </summary>
    public class BaseFileManager : IFileManager
    {
        /// <summary>
        /// Writes the text to the file
        /// </summary>
        /// <param name="text"></param>
        /// <param name="path">The path of the file</param>
        /// <param name="append">true:writes the text to the file</param>
        /// <returns></returns>
        public async Task WriteTexttoFile(string text, string path, bool append = false)
        {
            //Normalize Path
            path = NormalizePath(path);

            //Resolve to absolute path
            path = ResolvePath(path);


            //Lock the task
            await AsyncAwaiter.AwaitAsync(nameof(BaseFileManager) + path, async () =>
            {
                // Run the sync file access as a new task
                await TaskManager.Run(() =>
                {
                     using (var fileStream = (TextWriter)new StreamWriter(File.Open(path,append ? FileMode.Append : FileMode.Create)))
                         fileStream.Write(text);

                });
            });
        }

        public string NormalizePath(string path)
        {
            // Windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return path?.Replace('/', '\\').Trim();
            }
            //Linux
            else
            {
                return path?.Replace('\\', '/').Trim();
            }
        }

        /// <summary>
        /// resolves any relative elements of the path to absolute
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ResolvePath(string path)
        {
            return Path.GetFullPath(path);
        }
    }
}
