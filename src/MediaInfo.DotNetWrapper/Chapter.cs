using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper
{
    [PublicAPI]
    public class Chapter : MediaStream
    {
        public Chapter(MediaInfo info, int number, int position)
          : base(info, number, position)
        {
        }

        public override MediaStreamKind Kind => MediaStreamKind.Menu;

        protected override StreamKind StreamKind => StreamKind.Other;

        public double Offset { get; set; }

        public string Description { get; set; }
    }
}