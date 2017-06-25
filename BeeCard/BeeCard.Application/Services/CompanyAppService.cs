using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using BeeCard.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BeeCard.Application.Services
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyService _companyService;

        public CompanyAppService(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public void CreateCompany(string name, string address, string address2, string number, string postalCode, string neighborhood, string city, string state, string contactName, string contactEmail, string contactPhone, string password, SubscriptionType subscriptionType, decimal subscriptionPrice, DateTime subscriptionDate, SubscriptionStatus subscriptionStatus, string logo, string website, string socialNetwork, string cardIdentityConfig, Guid planId, Guid countryId, Guid companyTypeId)
        {
            var company = new Company();

            company.Address = address;
            company.Address2 = address2;
            company.CardIdentityConfig = cardIdentityConfig;
            company.City = city;
            company.CompanyTypeID = companyTypeId;
            company.ContactEmail = contactEmail;
            company.ContactName = contactName;
            company.ContactPhone = contactPhone;
            company.CountryID = countryId;
            company.Logo = logo;
            company.Name = name;
            company.Neighborhood = neighborhood;
            company.Number = number;
            company.Password = password;
            company.PlanID = planId;
            company.PostalCode = postalCode;
            company.SocialNetwork = socialNetwork;
            company.State = state;
            company.Status = EntityStatus.Active;
            company.SubscriptionDate = subscriptionDate;
            company.SubscriptionPrice = subscriptionPrice;
            company.SubscriptionStatus = subscriptionStatus;
            company.SubscriptionType = subscriptionType;
            company.Website = website;

            _companyService.Add(company);
        }

        public List<Company> GetCompanies()
        {
            return _companyService.Find(c => c.Status != EntityStatus.Deleted, f => f.Plan, f => f.Country, f => f.CompanyType).ToList();
        }

        public Company GetCompanyById(Guid companyId)
        {
            return _companyService.Find(c => c.ID == companyId && c.Status != EntityStatus.Deleted, f => f.Plan, f => f.CorporateCards, f => f.Country, f => f.CompanyType).FirstOrDefault();
        }

        public void RemoveCompany(Guid companyId)
        {
            var company = GetCompanyById(companyId);

            if (company != null)
                _companyService.Remove(company);
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }

        public void UpdateCompany(Guid companyId, string name, string address, string address2, string number, string postalCode, string neighborhood, string city, string state, string contactName, string contactEmail, string contactPhone, string password, SubscriptionType subscriptionType, decimal subscriptionPrice, DateTime subscriptionDate, SubscriptionStatus subscriptionStatus, string logo, string website, string socialNetwork, string cardIdentityConfig, Guid planId, Guid countryId, Guid companyTypeId, bool status)
        {
            var company = GetCompanyById(companyId);

            if (company != null)
            {
                company.Address = address;
                company.Address2 = address2;
                company.CardIdentityConfig = cardIdentityConfig;
                company.City = city;
                company.CompanyTypeID = companyTypeId;
                company.ContactEmail = contactEmail;
                company.ContactName = contactName;
                company.ContactPhone = contactPhone;
                company.CountryID = countryId;
                company.Logo = logo;
                company.Name = name;
                company.Neighborhood = neighborhood;
                company.Number = number;
                company.Password = password;
                company.PlanID = planId;
                company.PostalCode = postalCode;
                company.SocialNetwork = socialNetwork;
                company.State = state;
                company.SubscriptionDate = subscriptionDate;
                company.SubscriptionPrice = subscriptionPrice;
                company.SubscriptionStatus = subscriptionStatus;
                company.SubscriptionType = subscriptionType;
                company.Website = website;
                company.Status = status ? EntityStatus.Active : EntityStatus.Inactive;

                _companyService.Update(company);
            }
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }
    }
}
