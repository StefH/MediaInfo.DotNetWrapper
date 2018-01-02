using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using MediaInfo.DotNetWrapper.Enumerations;

namespace MediaInfo.DotNetWrapper.Models
{
    /// <summary>
    /// Describes properties of the menu
    /// </summary>
    /// <seealso cref="MediaStream" />
    [PublicAPI]
    public class MenuStream : MediaStream
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuStream"/> class.
        /// </summary>
        public MenuStream()
        {
            Chapters = new List<Chapter>();
        }

        /// <summary>
        /// Gets or sets the menu duration.
        /// </summary>
        /// <value>
        /// The menu duration.
        /// </value>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Gets the chapters.
        /// </summary>
        /// <value>
        /// The chapters.
        /// </value>
        public IList<Chapter> Chapters { get; }

        /// <inheritdoc />
        public override MediaStreamKind Kind => MediaStreamKind.Menu;

        /// <inheritdoc />
        protected override StreamKind StreamKind => StreamKind.Menu;

        /// <summary>
        /// Describes properties of the menu chapter
        /// </summary>
        [PublicAPI]
        public sealed class Chapter
        {
            /// <summary>
            /// Gets or sets the menu position.
            /// </summary>
            /// <value>
            /// The menu position.
            /// </value>
            public TimeSpan Position { get; set; }

            /// <summary>
            /// Gets or sets the menu chapter name.
            /// </summary>
            /// <value>
            /// The menu chapter name.
            /// </value>
            public string Name { get; set; }
        }
    }
}