using MediaInfo.DotNetWrapper.Models;

namespace MediaInfo.DotNetWrapper.Builder
{
    /// <summary>
    /// Describes base methods to build media stream with language
    /// </summary>
    /// <typeparam name="TStream">The type of the stream.</typeparam>
    internal abstract class LanguageMediaStreamBuilder<TStream> : MediaStreamBuilder<TStream> where TStream : LanguageMediaStream, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageMediaStreamBuilder{TStream}"/> class.
        /// </summary>
        /// <param name="info">The media info object.</param>
        /// <param name="number">The stream number.</param>
        /// <param name="position">The stream position.</param>
        protected LanguageMediaStreamBuilder(MediaInfo info, int number, int position)
          : base(info, number, position)
        {
        }

        /// <inheritdoc />
        public override TStream Build()
        {
            var result = base.Build();
            var language = Get("Language").ToLower();
            result.Language = LanguageHelper.GetLanguageByShortName(language);
            result.Default = Get<bool>("Default", bool.TryParse);
            result.Forced = Get<bool>("Forced", bool.TryParse);
            result.Lcid = LanguageHelper.GetLcidByShortName(language);
            return result;
        }
    }
}