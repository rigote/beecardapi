using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using BeeCard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeCard.Application.Services
{
    public class CountryAppService : ICountryAppService
    {
        private readonly ICountryService _countryService;

        public CountryAppService(ICountryService countryService)
        {
            _countryService = countryService;
        }


        public virtual List<Country> GetCountries()
        {
            return _countryService.Find(c => c.Status != EntityStatus.Deleted).ToList();
        }


        public virtual Country GetCountryById(Guid id)
        {
            Guid _id;
            if(Guid.TryParse(string.Format("{0}", id), out _id))
                      return _countryService.Find(c => c.ID == _id && c.Status != EntityStatus.Deleted).FirstOrDefault();
            else
                throw new ArgumentException(string.Empty, "Invalid data");
        }


        public virtual void CreateCountry(string name)
        {
            var country = _countryService.Find(c => c.Name.Contains(name)).FirstOrDefault();

            if (country == null)
            {
                country = new Country() { Name = name, Status = EntityStatus.Active };
                _countryService.Add(country);
            }
            else
                throw new ArgumentException(string.Empty, "Country already exists");
        }
        

        public virtual void UpdateCountry(Guid id, string name, EntityStatus status)
        {
            var country = GetCountryById(id);

            if (country != null)
            {
                country.Name = name;
                country.Status = status;
                _countryService.Update(country);
            }
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }

        public virtual void RemoveCountry(Guid id)
        {
            var country = GetCountryById(id);

            if (country != null)
                _countryService.Remove(country);
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }
    }
}
