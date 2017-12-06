using BeeCard.Application.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Services;
using BeeCard.Domain.Entities.Enum;

namespace BeeCard.Application.Services
{
    public class CompanyTypeAppService : ICompanyTypeAppService
    {
        private readonly ICompanyTypeService _companyTypeService;

        public CompanyTypeAppService(ICompanyTypeService companyTypeService)
        {
            _companyTypeService = companyTypeService;
        }

        public void CreateCompanyType(string name)
        {
            var companyType = new CompanyType();

            companyType.Name = name;
            companyType.Status = EntityStatus.Active;

            _companyTypeService.Add(companyType);
        }

        public CompanyType GetCompanyTypeById(Guid companyTypeId)
        {
            return _companyTypeService.Find(null, null, null, c => c.ID == companyTypeId && c.Status != EntityStatus.Deleted).Item2.FirstOrDefault();
        }

        public Tuple<long, List<CompanyType>> GetCompanyTypes(int? page, int? size)
        {
            return _companyTypeService.Find(page, size, o => o.ID, c => c.Status != EntityStatus.Deleted);
        }

        public void RemoveCompanyType(Guid companyTypeId)
        {
            var companyType = GetCompanyTypeById(companyTypeId);

            if (companyTypeId != null)
                _companyTypeService.Remove(companyType);
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }

        public void UpdateCompanyType(Guid companyTypeId, string name, bool status)
        {
            var companyType = GetCompanyTypeById(companyTypeId);

            if (companyType != null)
            {
                companyType.Name = name;
                companyType.Status = status ? EntityStatus.Active : EntityStatus.Inactive;

                _companyTypeService.Update(companyType);
            }
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }
    }
}
