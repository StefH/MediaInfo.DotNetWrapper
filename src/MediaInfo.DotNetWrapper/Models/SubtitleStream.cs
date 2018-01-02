using JetBrains.Annotations;
using MediaInfo.DotNetWrapper.Enumerations;

namespace MediaInfo.DotNetWrapper.Models
{
  /// <summary>
  /// Provides properties and overridden methods for the analyze subtitle stream 
  /// and contains information about subtitle.
  /// </summary>
  /// <seealso cref="LanguageMediaStream" />
  [PublicAPI]
  public class SubtitleStream : LanguageMediaStream
  {
    /// <summary>
    /// Gets the subtitle format.
    /// </summary>
    /// <value>
    /// The subtitle format.
    /// </value>
    public string Format { get; set; }

    /// <summary>
    /// Gets the subtitle codec.
    /// </summary>
    /// <value>
    /// The subtitle codec.
    /// </value>
    public SubtitleCodec Codec { get; set; }

    /// <inheritdoc />
    public override MediaStreamKind Kind => MediaStreamKind.Text;

    /// <inheritdoc />
    protected override StreamKind StreamKind => StreamKind.Text;
  }
}