using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [PublicAPI]
    public enum AudioCodec
    {
        A_UNDEFINED,
        A_MPEG_L1,
        A_MPEG_L2,
        A_MPEG_L3,
        A_PCM_INT_BIG,
        A_PCM_INT_LIT,
        A_PCM_FLOAT_IEEE,
        A_AC3,
        A_AC3_ATMOS,
        A_AC3_BSID9,
        A_AC3_BSID10,
        A_DTS,
        A_DTS_HD,
        A_EAC3,
        A_EAC3_ATMOS,
        A_FLAC,
        A_OPUS,
        A_TTA1,
        A_VORBIS,
        A_WAVPACK4,
        A_WAVPACK,
        A_WAVE,
        A_WAVE64,
        A_REAL_14_4,
        A_REAL_28_8,
        A_REAL_COOK,
        A_REAL_SIPR,
        A_REAL_RALF,
        A_REAL_ATRC,
        A_TRUEHD,
        A_TRUEHD_ATMOS,
        A_MLP,
        A_AAC,
        A_AAC_MPEG2_MAIN,
        A_AAC_MPEG2_LC,
        A_AAC_MPEG2_LC_SBR,
        A_AAC_MPEG2_SSR,
        A_AAC_MPEG4_MAIN,
        A_AAC_MPEG4_LC,
        A_AAC_MPEG4_LC_SBR,
        A_AAC_MPEG4_LC_SBR_PS,
        A_AAC_MPEG4_SSR,
        A_AAC_MPEG4_LTP,
        A_ALAC,
        A_APE,
        A_WMA1,
        A_WMA2,
        A_WMA9,
        A_ADPCM,
        A_AMR,
        A_ATRAC1,
        A_ATRAC3
    }
}