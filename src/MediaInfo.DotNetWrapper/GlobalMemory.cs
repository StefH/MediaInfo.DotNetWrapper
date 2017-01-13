using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper
{
    [PublicAPI]
    public class GlobalMemory : IDisposable
    {
        public GlobalMemory(IntPtr handle)
        {
            Handle = handle;
        }

        ~GlobalMemory()
        {
            Dispose(false);
        }

        public IntPtr Handle { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public static GlobalMemory StringToGlobalAnsi(string source)
        {
            return new GlobalMemory(Marshal.StringToHGlobalAnsi(source));
        }

        // ReSharper disable once UnusedParameter.Local
        private void Dispose(bool disposing)
        {
            if (Handle != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(Handle);
                Handle = IntPtr.Zero;
            }
        }
    }
}
