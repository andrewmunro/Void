using System;
using System.IO;
using System.Reflection;

namespace VoidLib.Common
{
    /// <summary>
    /// A class with utilities that can be used.
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Gets the application path.
        /// <value>The application path.</value>
        /// </summary>
        public static string ApplicationPath
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        }

        /// <summary>
        /// Gets the application version.
        /// </summary>
        public static Version Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().
                    GetName().Version;
            }
        }
    }
}
