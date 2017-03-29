using BeeCard.Domain.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace BeeCard.Domain.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<User> FindUser(string userName, string password);
        IdentityResult ChangePassword(Guid userId, string currentPassword, string newPassword);
    }
}
