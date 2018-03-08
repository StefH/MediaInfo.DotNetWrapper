#if !NETSTANDARD1_3
// ReSharper disable InconsistentNaming
using System;
using System.Runtime.InteropServices;

namespace MediaInfo.DotNetWrapper
{
    internal static class NativeSystemMethods
    {
        private const string Kernel32Dll = "kernel32.dll";

        //Import some stuff for module loading from kernel32.dll
        [DllImport(Kernel32Dll, SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr LoadLibrary(string lpFileName);

        [Flags]
        internal enum LoadLibraryFlags : uint
        {
            DONT_RESOLVE_DLL_REFERENCES = 0x00000001,
            LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,
            LOAD_LIBRARY_AS_DATAFILE = 0x00000002,
            LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,
            LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,
            LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
        }

        [DllImport(Kernel32Dll)]
        internal static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, LoadLibraryFlags dwFlags);

        [DllImport(Kernel32Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool FreeLibrary(IntPtr hModule);

        [DllImport(Kernel32Dll)]
        internal static extern long GetDriveType(string driveLetter);
    }
}
#endif