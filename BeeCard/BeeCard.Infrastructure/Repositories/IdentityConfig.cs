using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Entities;
using System.Threading.Tasks;
using System.Data;
using BeeCard.Domain.Entities.Enum;

namespace BeeCard.Infrastructure.Repositories
{
    public class IdentityDataAccess : IIdentityDataAccess
    {
        private readonly CustomUserManager<User> _userManager;
        private readonly Context _context;

        public IdentityDataAccess(Context context)
        {
            _context = context;
            _userManager = new CustomUserManager<User>(new CustomUserStore<User>(context));
        }

        public async Task<User> FindUser(string userName, string password)
        {
            User user = null;
            PasswordHasher hasher = new PasswordHasher();

            var query = _context.Set<User>()
                            .Where(u => (u.UserName == userName || u.PhoneNumber == userName) &&
                                    u.Status == EntityStatus.Active);

            using (_context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                 user = query.FirstOrDefault();
            }

            if (user != null && hasher.VerifyHashedPassword(user.PasswordHash, password) == PasswordVerificationResult.Success)
                return user;
            else
                return null;
        }

        public IdentityResult ChangePassword(Guid userId, string currentPassword, string newPassword)
        {
            var result = _userManager.ChangePassword(userId, currentPassword, newPassword);

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
