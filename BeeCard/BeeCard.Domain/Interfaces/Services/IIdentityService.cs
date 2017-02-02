using BeeCard.Domain.Entities;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace BeeCard.Domain.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<IdentityResult> RegisterUser(string userName, string password);
        Task<User> FindUser(string userName, string password);
    }
}
