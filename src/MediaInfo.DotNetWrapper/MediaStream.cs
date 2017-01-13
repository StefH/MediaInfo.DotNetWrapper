using System;
using System.Globalization;
using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper
{
    [PublicAPI]
    public abstract class MediaStream : MarshalByRefObject
    {
        protected MediaStream(MediaInfo info, int number, int position)
        {
            StreamNumber = number;
            StreamPosition = position;
            if (info != null)
            {
                AnalyzeStream(info);
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public abstract MediaStreamKind Kind { get; }

        protected abstract StreamKind StreamKind { get; }

        public int StreamPosition { get; }

        public int StreamNumber { get; private set; }

        protected virtual void AnalyzeStreamInternal(MediaInfo info)
        {
            Id = GetInt(info, "ID");
            Name = GetString(info, "Title");
        }

        private void AnalyzeStream(MediaInfo info)
        {
            AnalyzeStreamInternal(info);
        }

        protected long GetLong(MediaInfo info, string parameter)
        {
            long parsedValue;
            var result = info.Get(StreamKind, StreamPosition, parameter);
            return long.TryParse(result, out parsedValue) ? parsedValue : 0;
        }

        protected double GetDouble(MediaInfo info, string parameter)
        {
            NumberFormatInfo providerNumber = new NumberFormatInfo { NumberDecimalSeparator = "." };
            double parsedValue;
            var result = info.Get(StreamKind, StreamPosition, parameter);
            return double.TryParse(result, NumberStyles.AllowDecimalPoint, providerNumber, out parsedValue) ? parsedValue : 0;
        }

        protected int GetInt(MediaInfo info, string parameter)
        {
            int parsedValue;
            var result = info.Get(StreamKind, StreamPosition, parameter);
            return int.TryParse(result, out parsedValue) ? parsedValue : 0;
        }

        protected bool GetBool(MediaInfo info, string parameter)
        {
            bool parsedValue;
            var result = info.Get(StreamKind, StreamPosition, parameter);
            return bool.TryParse(result, out parsedValue) && parsedValue;
        }

        protected DateTime GetDateTime(MediaInfo info, string parameter)
        {
            DateTime parsedValue;
            var result = info.Get(StreamKind, StreamPosition, parameter);
            return DateTime.TryParse(result, out parsedValue) ? parsedValue : DateTime.MinValue;
        }

        protected string GetString(MediaInfo info, string parameter)
        {
            var result = info.Get(StreamKind, StreamPosition, parameter);
            return result ?? string.Empty;
        }
    }
}