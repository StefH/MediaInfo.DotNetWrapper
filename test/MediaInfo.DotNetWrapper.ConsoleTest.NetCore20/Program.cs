using System;
using System.IO;
using MediaInfo.DotNetWrapper.Enumerations;

namespace MediaInfo.DotNetWrapper.ConsoleTest.NetCore20
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

            var currentDirectory = AppContext.BaseDirectory;
            var mediaPath = Path.Combine(currentDirectory, "media");
            var mediaFiles = Directory.EnumerateFiles(mediaPath);
            // An example of how to use the library
            foreach (string filename in mediaFiles)
            {
                using (var mediaInfo = new MediaInfo())
                {
                    text += "\r\n\r\nOpen\r\n";
                    mediaInfo.Open(Path.Combine("media", filename));

                    text += "\r\n\r\nInform with Complete=false\r\n";
                    mediaInfo.Option("Complete");
                    text += mediaInfo.Inform();

                    text += "\r\n\r\nInform with Complete=true\r\n";
                    mediaInfo.Option("Complete", "1");
                    text += mediaInfo.Inform();

                    text += "\r\n\r\nCustom Inform\r\n";
                    mediaInfo.Option("Inform", "General;File size is %FileSize% bytes");
                    text += mediaInfo.Inform();

                    foreach (string param in new[] {"BitRate", "BitRate/String", "BitRate_Mode"})
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