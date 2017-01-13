using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum VideoCodec
    {
        V_UNDEFINED,
        V_UNCOMPRESSED,
        V_DIRAC,
        V_MPEG4,
        V_MPEG4_IS0_SP,
        V_MPEG4_IS0_ASP,
        V_MPEG4_IS0_AP,
        V_MPEG4_IS0_AVC,
        V_MPEG4_ISO_SP,
        V_MPEG4_ISO_ASP,
        V_MPEG4_ISO_AP,
        V_MPEG4_ISO_AVC,
        V_MPEGH_ISO_HEVC,
        V_MPEG4_MS_V1,
        V_MPEG4_MS_V2,
        V_MPEG4_MS_V3,
        V_VC1,
        V_MPEG1,
        V_MPEG2,
        V_PRORES,
        V_REAL_RV10,
        V_REAL_RV20,
        V_REAL_RV30,
        V_REAL_RV40,
        V_THEORA,
        V_VP6,
        V_VP8,
        V_VP9,
        V_DIVX1,
        V_DIVX2,
        V_DIVX3,
        V_DIVX4,
        V_DIVX50,
        V_XVID,
        V_SVQ1,
        V_SVQ2,
        V_SVQ3,
        V_SPRK,
        V_H260,
        V_H261,
        V_H263,
        V_AVDV,
        V_AVD1,
        V_FFV1,
        V_FFV2,
        V_IV21,
        V_IV30,
        V_IV40,
        V_IV50,
        V_FFDS,
        V_FRAPS,
        V_FFVH,
        V_MJPG,
        V_DV,
        V_HDV,
        V_DVCPRO50,
        V_DVCPRO100,
        V_WMV1,
        V_WMV2,
        V_WMV3,
        V_8BPS,
        V_BINKVIDEO
    }
}