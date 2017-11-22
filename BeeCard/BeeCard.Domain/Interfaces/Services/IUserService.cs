using BeeCard.Domain.Entities;
using System.Collections.Generic;

namespace BeeCard.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Dictionary<string, bool> CheckEmailPhone(string email, string phone);
        User FindByEmail(string email);
    }
}
