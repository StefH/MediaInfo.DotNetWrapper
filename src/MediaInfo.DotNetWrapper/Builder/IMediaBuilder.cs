using MediaInfo.DotNetWrapper.Models;

namespace MediaInfo.DotNetWrapper.Builder
{
    /// <summary>
    /// Describes media builder interface
    /// </summary>
    /// <typeparam name="TStream">The type of the stream.</typeparam>
    internal interface IMediaBuilder<out TStream> where TStream : MediaStream
    {
        /// <summary>
        /// Builds media stream.
        /// </summary>
        /// <returns></returns>
        TStream Build();
    }
}