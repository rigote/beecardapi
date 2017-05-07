using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using BeeCard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BeeCard.Application.Services
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyService _companyAppService;

        public CompanyAppService(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        public void Add(Company entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> Find(Expression<Func<Company, bool>> predicate = null, params Expression<Func<Company, object>>[] includeExpressions)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAll(params Expression<Func<Company, object>>[] includeExpressions)
        {
            throw new NotImplementedException();
        }

        public Company GetCompanyById(Guid companyId, Guid cardId)
        {
            return _companyAppService.Find(c => c.ID == companyId && c.Status == EntityStatus.Active).FirstOrDefault();
        }


        public void Remove(Company entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
