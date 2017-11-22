using BeeCard.Domain.Entities;
using System.Collections.Generic;

namespace BeeCard.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Dictionary<string, bool> CheckEmailPhone(string email, string phone);
        User FindByEmail(string email);
    }
}
