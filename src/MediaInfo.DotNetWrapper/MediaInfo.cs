using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using MediaInfo.DotNetWrapper.Enumerations;

namespace MediaInfo.DotNetWrapper
{
    [PublicAPI]
    public class MediaInfo : IDisposable
    {
        private IntPtr _handle;
        private readonly bool _mustUseAnsi;

        public MediaInfo()
        {
            try
            {
                _handle = NativeMethods.MediaInfo_New();
            }
            catch
            {
                _handle = IntPtr.Zero;
            }

#if !NETSTANDARD1_3
            _mustUseAnsi = Environment.OSVersion.ToString().IndexOf("Windows", StringComparison.OrdinalIgnoreCase) == -1;
#else
            _mustUseAnsi = true;
#endif
        }

        ~MediaInfo()
        {
            Dispose(false);
        }

        public Status Open(string fileName)
        {
            if (_handle == IntPtr.Zero)
            {
                return Status.None;
            }

            if (_mustUseAnsi)
            {
                using (var fileNameMemory = GlobalMemory.StringToGlobalAnsi(fileName))
                {
                    return (Status)NativeMethods.MediaInfoA_Open(_handle, fileNameMemory.Handle);
                }
            }

            return (Status)NativeMethods.MediaInfo_Open(_handle, fileName);
        }

        public Status OpenBufferInit(long fileSize, long fileOffset)
        {
            return _handle == IntPtr.Zero ? Status.None : (Status)NativeMethods.MediaInfo_Open_Buffer_Init(_handle, fileSize, fileOffset);
        }

        public Status OpenBufferContinue(IntPtr buffer, IntPtr bufferSize)
        {
            return _handle == IntPtr.Zero ? Status.None : (Status)NativeMethods.MediaInfo_Open_Buffer_Continue(_handle, buffer, bufferSize);
        }

        public long OpenBufferContinueGoToGet()
        {
            return _handle == IntPtr.Zero ? 0 : NativeMethods.MediaInfo_Open_Buffer_Continue_GoTo_Get(_handle);
        }

        public Status OpenBufferFinalize()
        {
            return _handle == IntPtr.Zero ? Status.None : (Status)NativeMethods.MediaInfo_Open_Buffer_Finalize(_handle);
        }

        public void Close()
        {
            if (_handle != IntPtr.Zero)
            {
                NativeMethods.MediaInfo_Close(_handle);
                NativeMethods.MediaInfo_Delete(_handle);
                _handle = IntPtr.Zero;
            }
        }

        public string Inform()
        {
            CheckHandle();

            return _mustUseAnsi
                     ? Marshal.PtrToStringAnsi(NativeMethods.MediaInfoA_Inform(_handle, IntPtr.Zero))
                     : Marshal.PtrToStringUni(NativeMethods.MediaInfo_Inform(_handle, IntPtr.Zero));
        }

        public string Get(StreamKind streamKind, int streamNumber, string parameter, InfoKind kindOfInfo = InfoKind.Text, InfoKind kindOfSearch = InfoKind.Name)
        {
            CheckHandle();

            if (_mustUseAnsi)
            {
                using (var parameterPtr = GlobalMemory.StringToGlobalAnsi(parameter))
                {
                    return
                      Marshal.PtrToStringAnsi(
                        NativeMethods.MediaInfoA_Get(
                          _handle,
                          (IntPtr)streamKind,
                          (IntPtr)streamNumber,
                          parameterPtr.Handle,
                          (IntPtr)kindOfInfo,
                          (IntPtr)kindOfSearch));
                }
            }

            return
              Marshal.PtrToStringUni(
                NativeMethods.MediaInfo_Get(
                  _handle,
                  (IntPtr)streamKind,
                  (IntPtr)streamNumber,
                  parameter,
                  (IntPtr)kindOfInfo,
                  (IntPtr)kindOfSearch));
        }

        public string Get(StreamKind streamKind, int streamNumber, int parameter, InfoKind kindOfInfo = InfoKind.Text)
        {
            CheckHandle();

            return _mustUseAnsi ?
              Marshal.PtrToStringAnsi(NativeMethods.MediaInfoA_GetI(_handle, (IntPtr)streamKind, (IntPtr)streamNumber, (IntPtr)parameter, (IntPtr)kindOfInfo)) :
              Marshal.PtrToStringUni(NativeMethods.MediaInfo_GetI(_handle, (IntPtr)streamKind, (IntPtr)streamNumber, (IntPtr)parameter, (IntPtr)kindOfInfo));
        }

        public string Option(string option, string value)
        {
            CheckHandle();

            if (_mustUseAnsi)
            {
                using (var optionPtr = GlobalMemory.StringToGlobalAnsi(option))
                using (var valuePtr = GlobalMemory.StringToGlobalAnsi(value))
                {
                    return Marshal.PtrToStringAnsi(NativeMethods.MediaInfoA_Option(_handle, optionPtr.Handle, valuePtr.Handle));
                }
            }

            return Marshal.PtrToStringUni(NativeMethods.MediaInfo_Option(_handle, option, value));
        }

        public IntPtr StateGet()
        {
            return _handle == IntPtr.Zero ? IntPtr.Zero : NativeMethods.MediaInfo_State_Get(_handle);
        }

        public int CountGet(StreamKind streamKind, int streamNumber = -1)
        {
            return _handle == IntPtr.Zero ? 0 : (int)NativeMethods.MediaInfo_Count_Get(_handle, (IntPtr)streamKind, (IntPtr)streamNumber);
        }

        //public string Get(StreamKind streamKind, int streamNumber, string parameter, InfoKind kindOfInfo)
        //{
        //    return Get(streamKind, streamNumber, parameter, kindOfInfo, InfoKind.Name);
        //}

        //public string Get(StreamKind streamKind, int streamNumber, string parameter)
        //{
        //    return Get(streamKind, streamNumber, parameter, InfoKind.Text, InfoKind.Name);
        //}

        //public string Get(StreamKind streamKind, int streamNumber, int parameter)
        //{
        //    return Get(streamKind, streamNumber, parameter, InfoKind.Text);
        //}

        public string Option(string option)
        {
            return Option(option, string.Empty);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            Close();
        }

        private void CheckHandle()
        {
            if (_handle == IntPtr.Zero)
            {
                throw new Exception("Unable to load MediaInfo library");
            }
        }
    }
}