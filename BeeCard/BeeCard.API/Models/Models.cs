namespace BeeCard.API.Models
{
    public class CardConfig
    {
        public string BgColor { get; set; }
        public string FontColor { get; set; }
    }

    public class CardSocialMedia
    {
        public SocialMediaType Type { get; set; }
        public string Url { get; set; }
    }

    public enum CardType
    {
        Personal = 0,
        Company = 1
    }

    public enum SocialMediaType
    {
        Facebook = 0,
        Linkedin = 1,
        Twitter = 2,
        Instagram = 3
    }
}