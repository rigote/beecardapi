﻿using System.Linq;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace BeeCard.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
            : base(context)
        {
            _context = context;
        }

        public Dictionary<string, bool> CheckEmailPhone(string email, string phone)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();

            var users = Find(null, null, null, u => u.Email == email || u.PhoneNumber == phone).ToList();

            result.Add("email", users.Any(a => a.Email == email));
            result.Add("phone", users.Any(a => a.PhoneNumber == phone));

            return result;
        }
    }
}
