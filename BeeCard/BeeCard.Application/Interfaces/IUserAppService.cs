﻿using BeeCard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeeCard.Application.Interfaces
{
    public interface IUserAppService
    {
        User GetUser(Guid id);
        User GetUserByEmail(string email);
        IEnumerable<User> GetAll();
        void RegisterUser(string email, string firstname, string lastname, string password, DateTime birthdate, string phoneNumber, string avatarFileName, byte[] avatarContent);
        void UpdateUser(Guid userId, string email, string firstname, string lastname, DateTime birthdate, string phoneNumber, string avatarFileName, byte[] avatarContent, bool status);
        void RemoveUser(Guid userId);
        Task<User> FindUser(string userName, string password);
        void ChangePassword(Guid userId, string currentPassword, string newPassword);
        UserGroup GetUserGroup(Guid userId, Guid userGroupId);        
        IEnumerable<UserGroup> GetAllUserGroups(Guid userId);
        void CreateUserGroup(Guid userId, string name);
        void UpdateUserGroup(Guid userId, Guid userGroupId, string name, bool status);
        void RemoveUserGroup(Guid userId, Guid userGroupId);
    }
}
