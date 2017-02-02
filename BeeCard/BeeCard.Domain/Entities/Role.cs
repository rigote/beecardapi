using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace BeeCard.Domain.Entities
{
    public class Role : IdentityRole<Guid, UserRole>
    {
    }
}
