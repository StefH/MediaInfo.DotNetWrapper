using MediaInfo.DotNetWrapper.Enumerations;
using MediaInfo.DotNetWrapper.Models;

namespace MediaInfo.DotNetWrapper.Builder
{
  /// <summary>
  /// Describes method to build chapter stream.
  /// </summary>
  internal class ChapterStreamBuilder : MediaStreamBuilder<ChapterStream>
  {
    public ChapterStreamBuilder(MediaInfo info, int number, int position)
      : base(info, number, position)
    {
    }

    /// <inheritdoc />
    public override MediaStreamKind Kind => MediaStreamKind.Menu;

    /// <inheritdoc />
    protected override StreamKind StreamKind => StreamKind.Other;
  }
}