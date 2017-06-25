using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using System;
using System.Collections.Generic;

namespace BeeCard.Application.Interfaces
{
    public interface ICompanyAppService
    {
        List<Company> GetCompanies();
        Company GetCompanyById(Guid companyId);
        void CreateCompany(string name, string address, string address2, string number, string postalCode, string neighborhood, string city, string state, string contactName, string contactEmail, string contactPhone, string password, SubscriptionType subscriptionType, decimal subscriptionPrice, DateTime subscriptionDate, SubscriptionStatus subscriptionStatus, string logo, string website, string socialNetwork, string cardIdentityConfig, Guid planId, Guid countryId, Guid companyTypeId);
        void UpdateCompany(Guid companyId, string name, string address, string address2, string number, string postalCode, string neighborhood, string city, string state, string contactName, string contactEmail, string contactPhone, string password, SubscriptionType subscriptionType, decimal subscriptionPrice, DateTime subscriptionDate, SubscriptionStatus subscriptionStatus, string logo, string website, string socialNetwork, string cardIdentityConfig, Guid planId, Guid countryId, Guid companyTypeId, bool status);
        void RemoveCompany(Guid companyId);
    }
}
