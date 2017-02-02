using System.Threading.Tasks;
using BeeCard.Application.Interfaces;
using Microsoft.AspNet.Identity;
using BeeCard.Domain.Interfaces.Services;
using BeeCard.Domain.Entities;

namespace BeeCard.Application.Services
{
    public class IdentityAppService : IIdentityAppService
    {
        private IIdentityService _service;

        public IdentityAppService(IIdentityService service)
        {
            _service = service;
        }

        public async Task<User> FindUser(string userName, string password)
        {
            return await _service.FindUser(userName, password);
        }

        public async Task<IdentityResult> RegisterUser(string userName, string password)
        {
            return await _service.RegisterUser(userName, password);
        }
    }
}
