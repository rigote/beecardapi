using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using System;

namespace BeeCard.API.Models
{
    public class BaseCountryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EntityStatus Status { get; set; }
    }


    public class RequestCountryModel : BaseCountryModel
    {
    }

    public class ResponseCountryModel : BaseCountryModel
    {
        public ResponseCountryModel(Country country)
        {
            Id = country.ID;
            Name = country.Name;
            Status = country.Status;
        }
    }
}