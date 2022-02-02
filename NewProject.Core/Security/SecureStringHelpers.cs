using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NewProject.Core
{
    /// <summary>
    /// helpers for the secureString class
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// unsecure password
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            if (secureString == null)
            {
                return string.Empty;
            }

            //get a pointer for an unsecure string
            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
