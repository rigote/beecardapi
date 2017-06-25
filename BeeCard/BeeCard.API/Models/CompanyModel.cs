using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BeeCard.API.Models
{
    public class BaseCompanyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Password { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
        public List<CardSocialMedia> SocialNetwork { get; set; }
        public CardConfig CardIdentityConfig { get; set; }
        public Guid PlanId { get; set; }
        public string PlanName { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public Guid CompanyTypeId { get; set; }
        public string CompanyTypeName { get; set; }
        public bool Status { get; set; }
    }

    public class ResponseCompanyModel : BaseCompanyModel
    {
        public ResponseCompanyModel()
        {
            SocialNetwork = new List<CardSocialMedia>();
        }

        public ResponseCompanyModel(Company company)
        {
            Id = company.ID;
            Name = company.Name;
            Address = company.Address;
            Address2 = company.Address2;
            Number = company.Number;
            PostalCode = company.PostalCode;
            Neighborhood = company.Neighborhood;
            City = company.City;
            State = company.State;
            ContactName = company.ContactName;
            ContactEmail = company.ContactEmail;
            ContactPhone = company.ContactPhone;
            Password = company.Password;
            SubscriptionType = company.SubscriptionType;
            SubscriptionPrice = company.SubscriptionPrice;
            SubscriptionDate = company.SubscriptionDate;
            SubscriptionStatus = company.SubscriptionStatus;
            Logo = company.Logo;
            Website = company.Website;
            SocialNetwork = JsonConvert.DeserializeObject<List<CardSocialMedia>>(company.SocialNetwork);
            CardIdentityConfig = JsonConvert.DeserializeObject<CardConfig>(company.CardIdentityConfig);
            PlanId = company.PlanID;
            PlanName = company.Plan != null ? company.Plan.Name : string.Empty;
            CountryId = company.CountryID;
            CountryName = company.Country != null ? company.Country.Name : string.Empty;
            CompanyTypeId = company.CompanyTypeID;
            CompanyTypeName = company.CompanyType != null ? company.CompanyType.Name : string.Empty;
            Status = company.Status == EntityStatus.Active ? true : false;
        }
    }

    public class RequestCompanyModel : BaseCompanyModel
    {
    }
    
    public class BaseCompanyTypeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }

    public class ResponseCompanyTypeModel : BaseCompanyTypeModel
    {
        public ResponseCompanyTypeModel(CompanyType companyType)
        {
            Id = companyType.ID;
            Name = companyType.Name;
            Status = companyType.Status == EntityStatus.Active ? true : false;
        }

        [JsonIgnore]
        public string Password { get; set; }
    }

    public class RequestCompanyTypeModel : BaseCompanyTypeModel
    {
    }
}