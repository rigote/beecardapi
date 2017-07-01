using System;
using System.Linq;
using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Interfaces.Services;
using BeeCard.Domain.Entities.Enum;
using System.Collections.Generic;

namespace BeeCard.Application.Services
{
    public class CardAppService : ICardAppService
    {
        private readonly IPersonalCardService _personalCardService;
        private readonly ICorporateCardService _corporateCardService;

        public CardAppService(IPersonalCardService personalCardService,
                              ICorporateCardService corporateCardService)
        {
            _personalCardService = personalCardService;
            _corporateCardService = corporateCardService;
        }

        public CorporateCard GetCorporateCardById(Guid userId, Guid cardId)
        {
            return _corporateCardService.Find(c => c.UserID == userId && c.ID == cardId && c.Status != EntityStatus.Deleted).FirstOrDefault();
        }

        public PersonalCard GetPersonalCardById(Guid userId, Guid cardId)
        {
            return _personalCardService.Find(c => c.UserID == userId && c.ID == cardId && c.Status != EntityStatus.Deleted).FirstOrDefault();
        }

        public List<PersonalCard> GetPersonalCards(Guid userId)
        {
            return _personalCardService.Find(c => c.UserID == userId && c.Status != EntityStatus.Deleted, i => i.User).ToList();
        }

        public List<CorporateCard> GetCorporateCards(Guid companyId)
        {
            return _corporateCardService.Find(c => c.CompanyID == companyId && c.Status != EntityStatus.Deleted, i => i.Company, i => i.User).ToList();
        }

        public void CreatePersonalCard(Guid userId, string avatarImage, string fullName, string address, string phone, string cellphone, string email, string website, string socialMedias)
        {
            var card = new PersonalCard();

            card.Address = address;
            card.Cellphone = cellphone;
            card.Email = email;
            card.Name = fullName;
            card.Phone = phone;
            card.SocialNetwork = socialMedias;
            card.UserID = userId;
            card.Website = website;
            card.Status = EntityStatus.Active;

            _personalCardService.Add(card);
        }

        public void UpdatePersonalCard(Guid userId, Guid cardId, string avatarImage, string fullName, string address, string phone, string cellphone, string email, string website, string socialMedias, bool status)
        {
            var card = GetPersonalCardById(userId, cardId);

            if (card != null)
            {
                card.Address = address;
                card.Cellphone = cellphone;
                card.Email = email;
                card.Name = fullName;
                card.Phone = phone;
                card.SocialNetwork = socialMedias;
                card.UserID = userId;
                card.Website = website;
                card.Status = status ? EntityStatus.Active : EntityStatus.Inactive;

                _personalCardService.Update(card);
            }                
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }

        public void RemovePersonalCard(Guid userId, Guid cardId)
        {
            var card = GetPersonalCardById(userId, cardId);

            if (card != null)
                _personalCardService.Remove(card);
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }

        public void CreateCorporateCard(Guid userId, Guid companyId, string fullName, string occupation, string department, string phone, string cellphone, string email, bool status)
        {
            var card = new CorporateCard();

            card.Cellphone = cellphone;
            card.CompanyID = companyId;
            card.Department = department;
            card.Email = email;
            card.Name = fullName;
            card.Occupation = occupation;
            card.Phone = phone;
            card.UserID = userId;
            card.Status = EntityStatus.Active;

            _corporateCardService.Add(card);
        }

        public void UpdateCorporateCard(Guid userId, Guid companyId, Guid cardId, string fullName, string occupation, string department, string phone, string cellphone, string email, bool status)
        {
            var card = GetCorporateCardById(userId, cardId);

            if (card != null)
            {
                card.Cellphone = cellphone;
                card.CompanyID = companyId;
                card.Department = department;
                card.Email = email;
                card.Name = fullName;
                card.Occupation = occupation;
                card.Phone = phone;
                card.UserID = userId;
                card.Status = status ? EntityStatus.Active : EntityStatus.Inactive;

                _corporateCardService.Update(card);
            }
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }

        public void RemoveCorporateCard(Guid userId, Guid cardId)
        {
            var card = GetCorporateCardById(userId, cardId);

            if (card != null)
                _corporateCardService.Remove(card);
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }
    }
}
