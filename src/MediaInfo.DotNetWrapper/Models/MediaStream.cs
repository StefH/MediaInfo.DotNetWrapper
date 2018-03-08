using System;
using JetBrains.Annotations;
using MediaInfo.DotNetWrapper.Enumerations;

namespace MediaInfo.DotNetWrapper.Models
{
    /// <summary>
    /// Provides basic properties and instance methods for the analyze stream 
    /// and contains information about media stream.
    /// </summary>
    /// <seealso cref="MarshalByRefObject" />
    [PublicAPI]
    public abstract class MediaStream 
#if !NETSTANDARD1_3    
    : MarshalByRefObject
#endif
    {
        /// <summary>
        /// Gets or sets the media steam id.
        /// </summary>
        /// <value>
        /// The media steam id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of stream.
        /// </summary>
        /// <value>
        /// The name of stream.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the kind of media stream.
        /// </summary>
        /// <value>
        /// The kind of media stream.
        /// </value>
        public abstract MediaStreamKind Kind { get; }

        /// <summary>
        /// Gets the kind of the stream.
        /// </summary>
        /// <value>
        /// The kind of the stream.
        /// </value>
        protected abstract StreamKind StreamKind { get; }

        /// <summary>
        /// Gets the stream position.
        /// </summary>
        /// <value>
        /// The stream position.
        /// </value>
        public int StreamPosition { get; set; }

        /// <summary>
        /// Gets the logical stream number.
        /// </summary>
        /// <value>
        /// The logical stream number.
        /// </value>
        public int StreamNumber { get; set; }
    }
}