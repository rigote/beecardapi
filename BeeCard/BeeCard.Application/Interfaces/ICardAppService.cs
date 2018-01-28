using BeeCard.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BeeCard.Application.Interfaces
{
    public interface ICardAppService
    {
        PersonalCard GetPersonalCardById(Guid userId, Guid cardId);
        CorporateCard GetCorporateCardById(Guid userId, Guid cardId);
        Tuple<long, List<PersonalCard>> GetPersonalCards(Guid userId, int? page, int? size);
        Tuple<long, List<CorporateCard>> GetCorporateCards(Guid userId, int? page, int? size);
        void CreatePersonalCard(Guid userId, string avatarImage, string fullName, string address, string address2, string number, string city, string postalCode, string neighborhood, string state, string phone, string cellphone, string email, string website, string socialMedias, string bio, List<string> skills);
        void UpdatePersonalCard(Guid userId, Guid cardId, string avatarImage, string fullName, string address, string address2, string number, string city, string postalCode, string neighborhood, string state, string phone, string cellphone, string email, string website, string socialMedias, string bio, List<string> skills, bool status);
        void RemovePersonalCard(Guid userId, Guid cardId);
        void CreateCorporateCard(Guid userId, Guid companyId, string fullName, string occupation, string department, string phone, string cellphone, string email, bool status);
        void UpdateCorporateCard(Guid userId, Guid companyId, Guid cardId, string fullName, string occupation, string department, string phone, string cellphone, string email, bool status);
        void RemoveCorporateCard(Guid userId, Guid cardId);
    }
}
