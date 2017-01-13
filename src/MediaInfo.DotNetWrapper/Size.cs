using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper
{
    [PublicAPI]
    public class Size
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
