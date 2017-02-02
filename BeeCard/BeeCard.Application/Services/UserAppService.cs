using System;
using System.Collections.Generic;
using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Services;
using System.Linq;

namespace BeeCard.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _service;

        public UserAppService(IUserService service)
        {
            _service = service;
        }

        public void AddUser(User user)
        {
            _service.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _service.GetAll();
        }

        public User GetUser(Guid id)
        {
            return _service.Find(u => u.Id == id).FirstOrDefault();
        }

        public void RemoveUser(User user)
        {
            _service.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _service.Update(user);
        }
    }
}
