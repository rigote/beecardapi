using BeeCard.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BeeCard.Application.Interfaces
{
    public interface ICompanyTypeAppService
    {
        List<CompanyType> GetCompanyTypes();
        CompanyType GetCompanyTypeById(Guid companyTypeId);
        void CreateCompanyType(string name);
        void UpdateCompanyType(Guid companyTypeId, string name, bool status);
        void RemoveCompanyType(Guid companyTypeId);
    }
}
