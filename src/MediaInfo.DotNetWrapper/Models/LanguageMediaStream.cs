using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper.Models
{
    /// <summary>
    /// Provides properties and overridden methods for the analyze stream 
    /// and contains information about media stream.
    /// </summary>
    /// <seealso cref="MediaStream" />
    [PublicAPI]
    public abstract class LanguageMediaStream : MediaStream
    {
        /// <summary>
        /// Gets the media stream language.
        /// </summary>
        /// <value>
        /// The media stream language.
        /// </value>
        public string Language { get; set; }

        /// <summary>
        /// Gets the media stream LCID.
        /// </summary>
        /// <value>
        /// The media stream LCID.
        /// </value>
        public int Lcid { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="LanguageMediaStream"/> is default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if default; otherwise, <c>false</c>.
        /// </value>
        public bool Default { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="LanguageMediaStream"/> is forced.
        /// </summary>
        /// <value>
        ///   <c>true</c> if forced; otherwise, <c>false</c>.
        /// </value>
        public bool Forced { get; set; }
    }
}