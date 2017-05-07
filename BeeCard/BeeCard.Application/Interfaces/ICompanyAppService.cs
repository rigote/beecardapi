using BeeCard.Domain.Entities;
using System;

namespace BeeCard.Application.Interfaces
{
    public interface ICompanyAppService
    {
        Company GetCompanyById(Guid userId, Guid cardId);
    }
}
