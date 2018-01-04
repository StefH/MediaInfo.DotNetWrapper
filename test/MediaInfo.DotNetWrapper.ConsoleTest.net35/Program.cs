using System;
using MediaInfo.DotNetWrapper.Enumerations;

namespace MediaInfo.DotNetWrapper.ConsoleTest.net35
{
    static class Program
    {
        static void Main(string[] args)
        {
            string text;
            using (var mediaInfo = new MediaInfo())
            {
                text = mediaInfo.Option("Info_Version");

                //Information about MediaInfo
                text += "\r\n\r\nInfo_Parameters\r\n";
                text += mediaInfo.Option("Info_Parameters");

                text += "\r\n\r\nInfo_Capacities\r\n";
                text += mediaInfo.Option("Info_Capacities");

                text += "\r\n\r\nInfo_Codecs\r\n";
                text += mediaInfo.Option("Info_Codecs");
            }

            // An example of how to use the library
            foreach (string filename in new[]
            {
                "Example.ogg",
                "RTL_7_Darts_WK_2014-2013-12-23_1_h263.3gp",
                "Test_H264.m2ts",
                "Test_H264_AC3.m2ts",
                "Test_H264_Atmos.m2ts",
                "Test_H264_DTS1.m2ts",
                "Test_H264_DTS2.m2ts",
                "Test_MP3Tags.mka",
                "Test_MP3Tags.mp3",
                "Test_MP3Tags_2.mp3"
            })
            {
                using (var mediaInfo = new MediaInfo())
                {
                    text += "\r\n\r\nOpen\r\n";
                    mediaInfo.Open(filename);

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
                }

                Console.WriteLine(text);
            }
        }
    }
}