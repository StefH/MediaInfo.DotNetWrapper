using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper.Enumerations
{
    [PublicAPI]
    public enum StreamKind
    {
        General,
        Video,
        Audio,
        Text,
        Other,
        Image,
        Menu
    }
}