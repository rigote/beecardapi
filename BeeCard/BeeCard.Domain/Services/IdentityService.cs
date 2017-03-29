using BeeCard.Domain.Interfaces.Services;
using Microsoft.AspNet.Identity;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace BeeCard.Domain.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityDataAccess _identityDataAccess;

        public IdentityService(IIdentityDataAccess identityDataAccess)
        {
            _identityDataAccess = identityDataAccess;
        }

        public async Task<User> FindUser(string userName, string password)
        {
            return await _identityDataAccess.FindUser(userName, password);          
        }

        public IdentityResult ChangePassword(Guid userId, string currentPassword, string newPassword)
        {
            return _identityDataAccess.ChangePassword(userId, currentPassword, newPassword);
        }
        
    }
}
