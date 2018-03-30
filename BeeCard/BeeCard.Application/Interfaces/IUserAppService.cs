using BeeCard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeeCard.Application.Interfaces
{
    public interface IUserAppService
    {
        User GetUser(Guid id);
        User GetUserByEmail(string email);
        Tuple<long, List<User>> GetAll(int? page, int? size);
        void RegisterUser(string email, string firstname, string lastname, string password, DateTime birthdate, string phoneNumber, string avatarBase64);
        void UpdateUser(Guid userId, string email, string firstname, string lastname, DateTime birthdate, string phoneNumber, string avatarBase64, bool status);
        void RemoveUser(Guid userId);
        Task<User> FindUser(string userName, string password);
        void ChangePassword(Guid userId, string currentPassword, string newPassword);
        UserGroup GetUserGroup(Guid userId, Guid userGroupId);        
        Tuple<long, List<UserGroup>> GetAllUserGroups(Guid userId, int? page, int? size);
        void CreateUserGroup(Guid userId, string name);
        void UpdateUserGroup(Guid userId, Guid userGroupId, string name, bool status);
        void RemoveUserGroup(Guid userId, Guid userGroupId);
        User FindByEmail(string email);
    }
}
