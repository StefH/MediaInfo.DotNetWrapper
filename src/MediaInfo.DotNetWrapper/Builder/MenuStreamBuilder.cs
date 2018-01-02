using System;
using MediaInfo.DotNetWrapper.Enumerations;
using MediaInfo.DotNetWrapper.Models;

namespace MediaInfo.DotNetWrapper.Builder
{
    /// <summary>
    /// Describes method to build menu stream.
    /// </summary>
    internal class MenuStreamBuilder : MediaStreamBuilder<MenuStream>
    {
        public MenuStreamBuilder(MediaInfo info, int number, int position)
          : base(info, number, position)
        {
        }

        /// <inheritdoc />
        public override MediaStreamKind Kind => MediaStreamKind.Menu;

        /// <inheritdoc />
        protected override StreamKind StreamKind => StreamKind.Menu;

        /// <inheritdoc />
        public override MenuStream Build()
        {
            var result = base.Build();
            var chapterStartId = Get<int>("Chapters_Pos_Begin", int.TryParse);
            var chapterEndId = Get<int>("Chapters_Pos_End", int.TryParse);
            for (var i = chapterStartId; i < chapterEndId; ++i)
            {
                result.Chapters.Add(new MenuStream.Chapter
                {
                    Name = Get(i, InfoKind.Text),
                    Position = Get<TimeSpan>(i, InfoKind.NameText, TimeSpan.TryParse)
                });
            }
            return result;
        }
    }
}