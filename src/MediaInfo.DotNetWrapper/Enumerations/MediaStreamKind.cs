using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper.Enumerations
{
    /// <summary>
    /// Defines constants for media stream kinds.
    /// </summary>
    [PublicAPI]
    public enum MediaStreamKind
    {
        /// <summary>
        /// The video stream
        /// </summary>
        Video,

        /// <summary>
        /// The audio stream
        /// </summary>
        Audio,

        /// <summary>
        /// The subtitle stream
        /// </summary>
        Text,

        /// <summary>
        /// The image stream
        /// </summary>
        Image,

        /// <summary>
        /// Menu
        /// </summary>
        Menu
    }
}