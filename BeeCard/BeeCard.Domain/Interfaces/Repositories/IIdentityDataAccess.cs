using BeeCard.Domain.Entities;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace BeeCard.Domain.Interfaces.Repositories
{
    public interface IIdentityDataAccess
    {
        Task<User> FindUser(string userName, string password);
        Task<IdentityResult> RegisterUser(string userName, string password);
    }
}
