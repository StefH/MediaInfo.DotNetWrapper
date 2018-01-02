using JetBrains.Annotations;
using MediaInfo.DotNetWrapper.Enumerations;

namespace MediaInfo.DotNetWrapper.Models
{
    /// <summary>
    /// Provides properties and overridden methods for the analyze chapter in media 
    /// and contains information about chapter.
    /// </summary>
    /// <seealso cref="MediaStream" />
    [PublicAPI]
    public class ChapterStream : MediaStream
    {
        /// <inheritdoc />
        public override MediaStreamKind Kind => MediaStreamKind.Menu;

        /// <inheritdoc />
        protected override StreamKind StreamKind => StreamKind.Other;

        /// <summary>
        /// Gets the chapter offset.
        /// </summary>
        /// <value>
        /// The chapter offset.
        /// </value>
        public double Offset { get; private set; }

        /// <summary>
        /// Gets the chapter description.
        /// </summary>
        /// <value>
        /// The chapter description.
        /// </value>
        public string Description { get; private set; }
    }
}