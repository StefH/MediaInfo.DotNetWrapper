using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper
{
    [PublicAPI]
    public class MediaInfoList : IDisposable
    {
        private IntPtr _handle;

        public MediaInfoList()
        {
            _handle = NativeMethods.MediaInfoList_New();
        }

        ~MediaInfoList()
        {
            Dispose(false);
        }

        public int Open(string fileName, InfoFileOptions options = InfoFileOptions.FileOption_Nothing)
        {
            return (int)NativeMethods.MediaInfoList_Open(_handle, fileName, (IntPtr)options);
        }

        public void Close(int filePos = -1)
        {
            NativeMethods.MediaInfoList_Close(_handle, (IntPtr)filePos);
        }

        public string Inform(int filePos)
        {
            return Marshal.PtrToStringUni(NativeMethods.MediaInfoList_Inform(_handle, (IntPtr)filePos, (IntPtr)0));
        }

        public string Get(int filePos, StreamKind streamKind, int streamNumber, string parameter, InfoKind kindOfInfo = InfoKind.Text, InfoKind kindOfSearch = InfoKind.Name)
        {
            return Marshal.PtrToStringUni(NativeMethods.MediaInfoList_Get(_handle, (IntPtr)filePos, (IntPtr)streamKind, (IntPtr)streamNumber, parameter, (IntPtr)kindOfInfo, (IntPtr)kindOfSearch));
        }

        public string Get(int filePos, StreamKind streamKind, int streamNumber, int parameter, InfoKind kindOfInfo = InfoKind.Text)
        {
            return Marshal.PtrToStringUni(NativeMethods.MediaInfoList_GetI(_handle, (IntPtr)filePos, (IntPtr)streamKind, (IntPtr)streamNumber, (IntPtr)parameter, (IntPtr)kindOfInfo));
        }

        public string Option(string option, string value)
        {
            return Marshal.PtrToStringUni(NativeMethods.MediaInfoList_Option(_handle, option, value));
        }

        public int StateGet()
        {
            return (int)NativeMethods.MediaInfoList_State_Get(_handle);
        }

        public int CountGet(int filePos, StreamKind streamKind, int streamNumber = -1)
        {
            return (int)NativeMethods.MediaInfoList_Count_Get(_handle, (IntPtr)filePos, (IntPtr)streamKind, (IntPtr)streamNumber);
        }

        //public string Get(int filePos, StreamKind streamKind, int streamNumber, string parameter, InfoKind kindOfInfo)
        //{
        //    return Get(filePos, streamKind, streamNumber, parameter, kindOfInfo, InfoKind.Name);
        //}

        //public string Get(int filePos, StreamKind streamKind, int streamNumber, string parameter)
        //{
        //    return Get(filePos, streamKind, streamNumber, parameter, InfoKind.Text, InfoKind.Name);
        //}

        //public string Get(int filePos, StreamKind streamKind, int streamNumber, int parameter)
        //{
        //    return Get(filePos, streamKind, streamNumber, parameter, InfoKind.Text);
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

        // ReSharper disable once UnusedParameter.Local
        private void Dispose(bool disposing)
        {
            if (_handle != IntPtr.Zero)
            {
                NativeMethods.MediaInfoList_Delete(_handle);
                _handle = IntPtr.Zero;
            }
        }
    }
}