﻿using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BeeCard.API.Models
{
    public class BaseCardModel
    {
        public string AvatarBase64 { get; set; }
        public string FullName { get; set; }                
        public string Phone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string Bio { get; set; }
        public List<CardSocialMedia> SocialMedias { get; set; }
        public List<string> Skills { get; set; }
        public bool Status { get; set; }        
    }

    public class ResponseCardModel : BaseCardModel
    {
        public Guid Id { get; set; }
        public CardType Type { get; set; }
        public string Occupation { get; set; }
        public string Department { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyName { get; set; }
        public bool IsFavorite { get; set; }
        public CardConfig Config { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }

        public ResponseCardModel()
        {
            SocialMedias = new List<CardSocialMedia>();
            Skills = new List<string>();
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
            Address2 = card.Address2;
            Number = card.Number;
            PostalCode = card.PostalCode;
            City = card.City;
            Neighborhood = card.Neighborhood;
            State = card.State;
            Skills = card.Skills.Select(c => c.Skill.Name).ToList();
            Bio = card.Bio;
            Occupation = card.Occupation;
            Status = card.Status == EntityStatus.Active ? true : false;
            UserId = card.UserID;
            AvatarBase64 = card.Photo;
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
            Department = card.Department;
            Status = card.Status == EntityStatus.Active ? true : false;
            UserId = card.UserID;
            CompanyId = card.CompanyID;

            if (card.User != null)
            {
                AvatarBase64 = card.User.Photo;
            }

            if (card.Company != null)
            {
                CompanyLogo = card.Company.Logo;
                CompanyName = card.Company.Name;
                Website = card.Company.Website;
                Address = card.Company.Address;
                Address2 = card.Company.Address2;
                Number = card.Company.Number;
                PostalCode = card.Company.PostalCode;
                City = card.Company.City;
                State = card.Company.State;
                Neighborhood = card.Company.Neighborhood;
                SocialMedias = JsonConvert.DeserializeObject<List<CardSocialMedia>>(card.Company.SocialNetwork);
                Config = JsonConvert.DeserializeObject<CardConfig>(card.Company.CardIdentityConfig);
            }
        }
    }

    public class RequestCardModel : BaseCardModel
    {
        public CardType Type { get; set; }
        public string Occupation { get; set; }
        public string Department { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyName { get; set; }
        public bool IsFavorite { get; set; }
        public CardConfig Config { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }

        public RequestCardModel()
        {
            SocialMedias = new List<CardSocialMedia>();
            Skills = new List<string>();
        }
    }
}