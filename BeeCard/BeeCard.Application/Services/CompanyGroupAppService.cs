using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using BeeCard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeCard.Application.Services
{
    public class CompanyGroupAppService : ICompanyGroupAppService
    {
        private readonly ICompanyGroupService _companyGroupService;
        private readonly ICompanyService _companyService;

        public CompanyGroupAppService(ICompanyGroupService companyGroupService,
                                      ICompanyService companyService)
        {
            _companyGroupService = companyGroupService;
            _companyService = companyService;
        }


        public virtual void CreateCompanyGroup(Guid companyId, string name, bool status)
        {
            CompanyAppService companyService = new CompanyAppService(_companyService);

            var company = companyService.GetCompanyById(companyId);

            if (company != null)
            {
                var companyGroup = new CompanyGroup()
                {
                    CompanyID = companyId,
                    Name = name,
                    Status = status ? EntityStatus.Active : EntityStatus.Inactive,
                };
                _companyGroupService.Add(companyGroup);

            }
            else
                throw new ArgumentException("Company not found.");
        }



        public CompanyGroup GetCompanyGroupById(Guid companyGroupId, Guid companyId)
        {
            return _companyGroupService.Find(c => c.CompanyID == companyId && c.ID == companyGroupId && c.Status != EntityStatus.Deleted).FirstOrDefault();
        }

        public List<CompanyGroup> GetCompanyGroups(Guid companyId)
        {
            return _companyGroupService.Find(c => c.CompanyID == companyId && c.Status != EntityStatus.Deleted).ToList();
        }

        public virtual void UpdateCompanyGroup(Guid companyGroupId, Guid companyId, string name, bool status)
        {
            var companyGroup = GetCompanyGroupById(companyGroupId, companyId);

            if (companyGroup != null)
            {
                companyGroup.Name = name;
                companyGroup.Status = status ? EntityStatus.Active : EntityStatus.Inactive;

                _companyGroupService.Update(companyGroup);
            }
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }


        public virtual void RemoveCompanyGroup(Guid companyGroupId, Guid companyId)
        {
            var companyGroup = GetCompanyGroupById(companyGroupId, companyId);

            if (companyGroup != null)
            {
                _companyGroupService.Remove(companyGroup);
            }
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }

    }
}
