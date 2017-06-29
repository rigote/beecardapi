using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using BeeCard.Domain.Interfaces.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //TODO: Save and Upload image
            //TODO: Apply password complexity (min len 8 | special characters?). 

            var user = new User();

            user.Email = email;
            user.UserName = email;
            user.Firstname = firstname;
            user.Lastname = lastname;

            PasswordHasher hasher = new PasswordHasher();
            user.PasswordHash = hasher.HashPassword(password);

            user.Birthdate = birthdate;
            user.PhoneNumber = phoneNumber;           
            user.Status = EntityStatus.Active;

            _service.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _service.GetAll();
        }

        public User GetUser(Guid id)
        {
            return _service.Find(u => u.Id == id && u.Status != EntityStatus.Deleted).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Invalid email");

            return _service.Find(u => u.Email == email && u.Status != EntityStatus.Deleted).FirstOrDefault();
        }

        public void RemoveUser(Guid userId)
        {
            var user = GetUser(userId);

            if (user != null)
            {
                _service.Remove(user);
            }
            else
            {
                throw new ArgumentException("Invalid user.");
            }
        }

        public void UpdateUser(Guid userId, string email, string firstname, string lastname, DateTime birthdate, string phoneNumber, string avatarFileName, byte[] avatarContent, bool status)
        {
            //TODO: Save and Upload image

            var user = GetUser(userId);

            if (user != null)
            {
                user.Firstname = firstname;
                user.Lastname = lastname;
                user.Birthdate = birthdate;
                user.PhoneNumber = phoneNumber;
                user.Status = status ? EntityStatus.Active : EntityStatus.Inactive;

                _service.Update(user);
            }
            else
            {
                throw new ArgumentException("Invalid user.");
            }
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
