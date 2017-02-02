using System.Threading.Tasks;
using BeeCard.Domain.Interfaces.Services;
using Microsoft.AspNet.Identity;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;

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

        public async Task<IdentityResult> RegisterUser(string userName, string password)
        {
            return await _identityDataAccess.RegisterUser(userName, password);
        }
    }
}
