using System;
using System.Collections.Generic;
using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using BeeCard.Domain.Entities.Enum;

namespace BeeCard.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _service;
        private readonly IIdentityService _identityService;

        public UserAppService(IUserService service, IIdentityService identityService)
        {
            _service = service;
            _identityService = identityService;
        }

        public void RegisterUser(string email, string firstname, string lastname, string password, DateTime birthdate, string phoneNumber, string avatarFileName, byte[] avatarContent)
        {
            //TODO: Upload image

            var user = new User();

            user.Email = email;
            user.UserName = email;
            user.Firstname = firstname;
            user.Lastname = lastname;

            PasswordHasher hasher = new PasswordHasher();
            user.PasswordHash = hasher.HashPassword(password);

            user.Birthdate = birthdate;
            user.PhoneNumber = phoneNumber;
            user.PhoneNumber = avatarFileName;
            user.Status = EntityStatus.Active;

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

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Invalid email");

            return _service.Find(u => u.Email == email).FirstOrDefault();
        }

        public void RemoveUser(User user)
        {
            _service.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _service.Update(user);
        }

        public async Task<User> FindUser(string userName, string password)
        {
            return await _identityService.FindUser(userName, password);
        }

        public void ChangePassword(Guid userId, string currentPassword, string newPassword)
        {
            var result = _identityService.ChangePassword(userId, currentPassword, newPassword);
        }
    }
}
