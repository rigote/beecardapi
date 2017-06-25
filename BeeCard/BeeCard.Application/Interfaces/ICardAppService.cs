using BeeCard.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BeeCard.Application.Interfaces
{
    public interface ICardAppService
    {
        PersonalCard GetPersonalCardById(Guid userId, Guid cardId);
        CorporateCard GetCorporateCardById(Guid userId, Guid cardId);
        List<PersonalCard> GetPersonalCards(Guid userId);
        List<CorporateCard> GetCorporateCards(Guid userId);
        void CreatePersonalCard(Guid userId, string avatarImage, string fullName, string address, string phone, string cellphone, string email, string website, string socialMedias);
        void UpdatePersonalCard(Guid userId, Guid cardId, string avatarImage, string fullName, string address, string phone, string cellphone, string email, string website, string socialMedias, bool status);
        void RemovePersonalCard(Guid userId, Guid cardId);
    }
}
