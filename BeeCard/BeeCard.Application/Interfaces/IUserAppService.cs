using BeeCard.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BeeCard.Application.Interfaces
{
    public interface IUserAppService
    {
        User GetUser(Guid id);
        IEnumerable<User> GetAll();
        void AddUser(User user);
        void UpdateUser(User user);
        void RemoveUser(User user);
    }
}
