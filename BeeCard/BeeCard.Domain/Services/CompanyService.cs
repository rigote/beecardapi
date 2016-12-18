using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Services;
using BeeCard.Domain.Interfaces.Repositories;

namespace BeeCard.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public void Add(Company entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<Company> Find(Expression<Func<Company, bool>> predicate = null, params Expression<Func<Company, object>>[] includeExpressions)
        {
            return _repository.Find(predicate, includeExpressions);
        }

        public IEnumerable<Company> GetAll(params Expression<Func<Company, object>>[] includeExpressions)
        {
            return _repository.GetAll(includeExpressions);
        }

        public void Remove(Company entity)
        {
            _repository.Remove(entity);
        }

        public void Update(Company entity)
        {
            _repository.Update(entity);
        }
    }
}
