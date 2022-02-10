using System.Threading.Tasks;

namespace NewProject.Core
{
    /// <summary>
    /// Handles reading/writing the file system
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Writes the text to the file
        /// </summary>
        /// <param name="text"></param>
        /// <param name="path">The path of the file</param>
        /// <param name="append">true:writes the text to the file</param>
        /// <returns></returns>
        Task WriteTexttoFile(string text, string path, bool append = false);

        /// <summary>
        /// Normalizing a path based on current OS
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string NormalizePath(string path);

        /// <summary>
        /// resolves any relative elements of the path to absolute
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string ResolvePath(string path);
    }
}
