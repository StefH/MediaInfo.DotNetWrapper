using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper
{
    [PublicAPI]
    public enum MediaStreamKind
    {
        Video,
        Audio,
        Text,
        Image,
        Menu
    }
}