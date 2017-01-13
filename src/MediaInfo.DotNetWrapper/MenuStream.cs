namespace MediaInfo.DotNetWrapper
{
    public class MenuStream : MediaStream
    {
        public MenuStream(MediaInfo info, int number, int position)
          : base(info, number, position)
        {
        }

        public override MediaStreamKind Kind => MediaStreamKind.Menu;

        protected override StreamKind StreamKind => StreamKind.Menu;
    }
}