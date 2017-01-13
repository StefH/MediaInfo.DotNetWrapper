using System;

namespace MediaInfo.DotNetWrapper.ConsoleTest
{
    static class Program
    {
        static void Main(string[] args)
        {
            using (var mediaInfo = new MediaInfo())
            {
                string text = mediaInfo.Option("Info_Version");

                //Information about MediaInfo
                text += "\r\n\r\nInfo_Parameters\r\n";
                text += mediaInfo.Option("Info_Parameters");

                text += "\r\n\r\nInfo_Capacities\r\n";
                text += mediaInfo.Option("Info_Capacities");

                text += "\r\n\r\nInfo_Codecs\r\n";
                text += mediaInfo.Option("Info_Codecs");

                //An example of how to use the library
                text += "\r\n\r\nOpen\r\n";
                mediaInfo.Open("Example.ogg"); //Must be the complete path (ie "C:\\Example.ogg")

                text += "\r\n\r\nInform with Complete=false\r\n";
                mediaInfo.Option("Complete");
                text += mediaInfo.Inform();

                text += "\r\n\r\nInform with Complete=true\r\n";
                mediaInfo.Option("Complete", "1");
                text += mediaInfo.Inform();

                text += "\r\n\r\nCustom Inform\r\n";
                mediaInfo.Option("Inform", "General;File size is %FileSize% bytes");
                text += mediaInfo.Inform();

                foreach (string param in new[] { "BitRate", "BitRate/String", "BitRate_Mode" })
                {
                    text += "\r\n\r\nGet with Stream=Audio and Parameter='" + param + "'\r\n";
                    text += mediaInfo.Get(StreamKind.Audio, 0, param);
                }

                text += "\r\n\r\nGet with Stream=General and Parameter=46\r\n";
                text += mediaInfo.Get(StreamKind.General, 0, 46);

                text += "\r\n\r\nCount_Get with StreamKind=Stream_Audio\r\n";
                text += mediaInfo.CountGet(StreamKind.Audio);

                text += "\r\n\r\nGet with Stream=General and Parameter='AudioCount'\r\n";
                text += mediaInfo.Get(StreamKind.General, 0, "AudioCount");

                text += "\r\n\r\nGet with Stream=Audio and Parameter='StreamCount'\r\n";
                text += mediaInfo.Get(StreamKind.Audio, 0, "StreamCount");

                text += "\r\n\r\nDispose / Close\r\n";

                Console.WriteLine(text);
            }
        }
    }
}