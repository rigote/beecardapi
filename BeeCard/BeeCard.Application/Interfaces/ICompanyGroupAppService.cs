using BeeCard.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BeeCard.Application.Interfaces
{
    public interface ICompanyGroupAppService
    {
        void CreateCompanyGroup(Guid companyId, string name, bool status);
        CompanyGroup GetCompanyGroupById(Guid companyGroupId, Guid companyId);
        List<CompanyGroup> GetCompanyGroups(Guid companyId);
        void UpdateCompanyGroup(Guid companyGroupId, Guid companyId, string name, bool status);
        void RemoveCompanyGroup(Guid companyGroupId, Guid companyId);

    }
}
