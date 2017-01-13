using System.Collections.Generic;
using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper
{
    [PublicAPI]
    public class SubtitleStream : LanguageMediaStream
    {
        #region match dictionary

        private static readonly Dictionary<string, SubtitleCodec> SubtitleCodecs = new Dictionary<string, SubtitleCodec>
        {
            { "S_ASS", SubtitleCodec.S_ASS },
            { "S_IMAGE/BMP", SubtitleCodec.S_IMAGE_BMP },
            { "S_SSA", SubtitleCodec.S_SSA },
            { "S_TEXT/ASS", SubtitleCodec.S_TEXT_ASS },
            { "S_TEXT/SSA", SubtitleCodec.S_TEXT_SSA },
            { "S_TEXT/USF", SubtitleCodec.S_TEXT_USF },
            { "S_TEXT/UTF8", SubtitleCodec.S_TEXT_UTF8 },
            { "S_USF", SubtitleCodec.S_USF },
            { "S_UTF8", SubtitleCodec.S_UTF8 },
            { "S_VOBSUB", SubtitleCodec.S_VOBSUB },
            { "S_HDMV/PGS", SubtitleCodec.S_HDMV_PGS },
            { "S_HDMV/TEXTST", SubtitleCodec.S_HDMV_TEXTST }
        };

        #endregion

        public SubtitleStream(MediaInfo info, int number, int position)
            : base(info, number, position)
        {
        }

        public string Format { get; private set; }

        public SubtitleCodec Codec { get; private set; }

        public override MediaStreamKind Kind => MediaStreamKind.Text;

        protected override StreamKind StreamKind => StreamKind.Text;

        protected override void AnalyzeStreamInternal(MediaInfo info)
        {
            base.AnalyzeStreamInternal(info);
            Format = GetString(info, "Format");
            Codec = GetCodec(GetString(info, "CodecID").ToUpper());
        }

        private static SubtitleCodec GetCodec(string source)
        {
            SubtitleCodec result;
            return SubtitleCodecs.TryGetValue(source, out result) ? result : SubtitleCodec.S_UNDEFINED;
        }
    }
}