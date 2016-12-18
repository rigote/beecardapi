using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Domain.Services
{
    public class UserGroupService : BaseService<UserGroup>, IUserGroupService
    {
        private readonly IUserGroupRepository _repository;

        public UserGroupService(IUserGroupRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
