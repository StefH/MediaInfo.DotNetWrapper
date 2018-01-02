using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper.Enumerations
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [Flags]
    public enum InfoFileOptions
    {
        FileOption_Nothing = 0x00,
        FileOption_NoRecursive = 0x01,
        FileOption_CloseAll = 0x02,
        FileOption_Max = 0x04
    }
}