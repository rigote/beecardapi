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
        private readonly IUserGroupService _userGroupService;

        public UserAppService(IUserService service, IIdentityService identityService, IUserGroupService userGroupService)
        {
            _service = service;
            _identityService = identityService;
            _userGroupService = userGroupService;
        }

        public void RegisterUser(string email, string firstname, string lastname, string password, DateTime birthdate, string phoneNumber, string avatarBase64)
        {
            var dataExists = _service.CheckEmailPhone(email, phoneNumber);

            if (dataExists["email"])
                throw new ArgumentException("email_already_exists");

            if (dataExists["phone"])
                throw new ArgumentException("phone_already_exists");

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
            user.Photo = avatarBase64;

            _service.Add(user);
        }

        public Tuple<long, List<User>> GetAll(int? page, int? size)
        {
            return _service.Find(page, size, o => o.Id, u => u.Status != EntityStatus.Deleted);
        }

        public User GetUser(Guid id)
        {
            return _service.Find(null, null, null, u => u.Id == id && u.Status != EntityStatus.Deleted).Item2.FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("invalid_email");

            return _service.Find(null, null, null, u => u.Email == email && u.Status != EntityStatus.Deleted).Item2.FirstOrDefault();
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
                throw new ArgumentException("invalid_user");
            }
        }

        public void UpdateUser(Guid userId, string email, string firstname, string lastname, DateTime birthdate, string phoneNumber, string avatarBase64, bool status)
        {
            var user = GetUser(userId);

            if (user != null)
            {
                user.Firstname = firstname;
                user.Lastname = lastname;
                user.Birthdate = birthdate;
                user.PhoneNumber = phoneNumber;
                user.Status = status ? EntityStatus.Active : EntityStatus.Inactive;
                user.Photo = avatarBase64;

                _service.Update(user);
            }
            else
            {
                throw new ArgumentException(string.Empty, "NotFound");
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

        public UserGroup GetUserGroup(Guid userId, Guid userGroupId)
        {
            return _userGroupService.Find(null, null, null, u => u.UserID == userId && u.ID == userGroupId && u.Status != EntityStatus.Deleted).Item2.FirstOrDefault();
        }

        public Tuple<long, List<UserGroup>> GetAllUserGroups(Guid userId, int? page, int? size)
        {
            return _userGroupService.Find(page, size, o => o.ID, u => u.Status != EntityStatus.Deleted);
        }

        public void CreateUserGroup(Guid userId, string name)
        {
            var userGroup = new UserGroup();

            userGroup.UserID = userId;
            userGroup.Name = name;
            userGroup.Status = EntityStatus.Active;

            _userGroupService.Add(userGroup);
        }

        public void UpdateUserGroup(Guid userId, Guid userGroupId, string name, bool status)
        {
            var userGroup = GetUserGroup(userId, userGroupId);

            if (userGroup != null)
            {
                userGroup.Name = name;
                userGroup.Status = status ? EntityStatus.Active : EntityStatus.Inactive;

                _userGroupService.Update(userGroup);
            }
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }

        public void RemoveUserGroup(Guid userId, Guid userGroupId)
        {
            var userGroup = GetUserGroup(userId, userGroupId);

            if (userGroup != null)
                _userGroupService.Remove(userGroup);
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }

        public User FindByEmail(string email)
        {
            return _service.FindByEmail(email);
        }

    }
}
