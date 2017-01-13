using JetBrains.Annotations;

namespace MediaInfo.DotNetWrapper
{
    [PublicAPI]
    public abstract class LanguageMediaStream : MediaStream
    {
        protected LanguageMediaStream(MediaInfo info, int number, int position)
            : base(info, number, position)
        {
        }

        public string Language { get; set; }

        public int Lcid { get; set; }

        public bool Default { get; set; }

        public bool Forced { get; set; }

        protected override void AnalyzeStreamInternal(MediaInfo info)
        {
            base.AnalyzeStreamInternal(info);
            var language = GetString(info, "Language").ToLower();
            Default = GetBool(info, "Default");
            Forced = GetBool(info, "Forced");
            Language = LanguageHelper.GetLanguageByShortName(language);
            Lcid = LanguageHelper.GetLcidByShortName(language);
        }
    }
}