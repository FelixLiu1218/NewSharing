namespace NewProject.Core
{
    /// <summary>
    /// The severity of log message
    /// </summary>
    public enum LogFactoryLevel
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
        /// Logs warnings,errors,standard messages
        /// </summary>
        Normal = 4,

        /// <summary>
        /// Logs Critical errors and warnings
        /// </summary>
        Critical= 5,

        /// <summary>
        /// Output nothing
        /// </summary>
        Empty = 6,
    }
}
