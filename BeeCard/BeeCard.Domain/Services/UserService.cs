using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace BeeCard.Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Dictionary<string, bool> CheckEmailPhone(string email, string phone)
        {
            return _repository.CheckEmailPhone(email, phone);
        }
    }
}
