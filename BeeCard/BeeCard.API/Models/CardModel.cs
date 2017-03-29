using BeeCard.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BeeCard.API.Models
{
    public class BaseCardModel
    {
        public string AvatarImage { get; set; }
        public string FullName { get; set; }                
        public string Phone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public List<CardSocialMedia> SocialMedias { get; set; }
    }

    public class ResponseCardModel : BaseCardModel
    {
        public Guid Id { get; set; }
        public CardType Type { get; set; }
        public string Occupation { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyName { get; set; }
        public bool IsFavorite { get; set; }
        public CardConfig Config { get; set; }

        public ResponseCardModel()
        {
            SocialMedias = new List<CardSocialMedia>();
        }

        public ResponseCardModel(PersonalCard card)
        {
            Id = card.ID;
            Type = CardType.Personal;
            Phone = card.Phone;
            Cellphone = card.Cellphone;
            Email = card.Email;
            Website = card.Website;
            SocialMedias = JsonConvert.DeserializeObject<List<CardSocialMedia>>(card.SocialNetwork);
            FullName = card.Name;
            Address = card.Address;

            if (card.User != null)
            {
                AvatarImage = card.User.Photo;     
            }

        }

        public ResponseCardModel(CorporateCard card)
        {
            Id = card.ID;
            Type = CardType.Company;
            Phone = card.Phone;
            Cellphone = card.Cellphone;
            Email = card.Email;
            FullName = card.Name;
            Occupation = card.Occupation;

            if (card.User != null)
            {
                AvatarImage = card.User.Photo;
            }

            if (card.Company != null)
            {
                CompanyLogo = card.Company.Logo;
                CompanyName = card.Company.Name;
                Website = card.Company.Website;
                Address = string.Format("{0} - {1} {2} {3}-{4}", card.Company.Address, card.Company.Neighborhood, card.Company.PostalCode, card.Company.City, card.Company.State);
                SocialMedias = JsonConvert.DeserializeObject<List<CardSocialMedia>>(card.Company.SocialNetwork);
                Config = JsonConvert.DeserializeObject<CardConfig>(card.Company.CardIdentityConfig);
            }
        }
    }

    public class RequestCardModel : BaseCardModel
    {
    }

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