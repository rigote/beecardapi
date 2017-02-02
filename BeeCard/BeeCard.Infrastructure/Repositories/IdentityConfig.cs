using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Entities;

namespace BeeCard.Infrastructure.Repositories
{
    public class IdentityDataAccess : IIdentityDataAccess
    {
        private readonly CustomUserManager<User> _userManager;

        public IdentityDataAccess(Context context)
        {
            _userManager = new CustomUserManager<User>(new CustomUserStore<User>(context));
        }

        public async Task<User> FindUser(string userName, string password)
        {
            User user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public async Task<IdentityResult> RegisterUser(string userName, string password)
        {
            User user = new User
            {
                UserName = userName
            };

            var result = await _userManager.CreateAsync(user, password);

            return result;
        }
    }

    public class CustomUserStore<TUser> : UserStore<TUser, Role, Guid, UserLogin, UserRole, UserClaim>, IUserStore<TUser, Guid>, IDisposable where TUser : User
    {
        private readonly Context _context;

        public CustomUserStore(Context context)
            : base(context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
                
    }
    
    public class CustomUserManager<TUser> : UserManager<TUser, Guid> where TUser : class, IUser<Guid>
    {
        public CustomUserManager(IUserStore<TUser, Guid> store) 
            : base(store)
        {
        }
    }
}
