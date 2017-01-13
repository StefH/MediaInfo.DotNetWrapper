using System.Diagnostics.CodeAnalysis;

namespace MediaInfo.DotNetWrapper
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum SubtitleCodec
    {
        S_UNDEFINED,
        S_ASS,
        S_IMAGE_BMP,
        S_SSA,
        S_TEXT_ASS,
        S_TEXT_SSA,
        S_TEXT_USF,
        S_TEXT_UTF8,
        S_USF,
        S_UTF8,
        S_VOBSUB,
        S_HDMV_PGS,
        S_HDMV_TEXTST
    }
}