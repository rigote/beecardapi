using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using System;
using System.Collections.Generic;

namespace BeeCard.Application.Interfaces
{
    public interface ICountryAppService
    {
        List<Country> GetCountries(int? page, int? size);
        void CreateCountry(string name);
        void UpdateCountry(Guid id, string name, EntityStatus status);
        Country GetCountryById(Guid id);
        void RemoveCountry(Guid id);
    }
}
