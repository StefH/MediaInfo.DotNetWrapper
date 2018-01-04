using System;

namespace MediaInfo.DotNetWrapper
{
    internal static class Utils
    {
        public static bool Is64BitProcess
        {
            get
            {
#if NET35
                return IntPtr.Size == 8;
#else
                return Environment.Is64BitProcess;
#endif
            }
        }
    }
}