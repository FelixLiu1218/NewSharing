namespace NewProject.Core
{
    /// <summary>
    /// The severity of log message
    /// </summary>
    public enum LogOutputLevel
    {
        /// <summary>
        /// Logs everything
        /// </summary>
        Debug =1,

        /// <summary>
        /// Logs all information but debug
        /// </summary>
        Verbose =2,

        /// <summary>
        /// Logs all informative message,expert debug and verbose messages
        /// </summary>
        Informative =3,

        /// <summary>
        /// Logs Critical errors, warnings and success
        /// </summary>
        Critical= 4,

        /// <summary>
        /// Output nothing
        /// </summary>
        Empty = 7,
    }
}
