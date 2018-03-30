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
        private readonly ISkillAppService _skillService;
        private readonly IPersonalCardService _personalCardService;
        private readonly ICorporateCardService _corporateCardService;

        public CardAppService(ISkillAppService skillService,
                              IPersonalCardService personalCardService,
                              ICorporateCardService corporateCardService)
        {
            _skillService = skillService;
            _personalCardService = personalCardService;
            _corporateCardService = corporateCardService;
        }

        public CorporateCard GetCorporateCardById(Guid userId, Guid cardId)
        {
            return _corporateCardService.Find(null, null, null, c => c.UserID == userId && c.ID == cardId && c.Status != EntityStatus.Deleted).Item2.FirstOrDefault();
        }

        public PersonalCard GetPersonalCardById(Guid userId, Guid cardId)
        {
            return _personalCardService.Find(null, null, null, c => c.UserID == userId && c.ID == cardId && c.Status != EntityStatus.Deleted, c => c.Skills.Select(s => s.Skill)).Item2.FirstOrDefault();
        }

        public Tuple<long, List<PersonalCard>> GetPersonalCards(Guid userId, int? page, int? size)
        {
            return _personalCardService.Find(page, size, o => o.ID, c => c.UserID == userId && c.Status != EntityStatus.Deleted, i => i.User);
        }

        public Tuple<long, List<CorporateCard>> GetCorporateCards(Guid companyId, int? page, int? size)
        {
            return _corporateCardService.Find(page, size, o =>o.ID, c => c.CompanyID == companyId && c.Status != EntityStatus.Deleted, i => i.Company, i => i.User);
        }

        public void CreatePersonalCard(Guid userId, string fullName, string address, string address2, string number, string city, string postalCode, string neighborhood, string state, string phone, string cellphone, string email, string website, string socialMedias, string bio, List<string> skills, string avatarBase64)
        {
            List<Skill> _skills = new List<Skill>();

            foreach (var skill in skills)
                _skills.Add(_skillService.Save(skill));            

            var card = new PersonalCard();

            card.Address = address;
            card.Address2 = address2;
            card.Bio = bio;
            card.City = city;
            card.Neighborhood = neighborhood;
            card.Number = number;
            card.PostalCode = postalCode;            
            card.State = state;            
            card.Cellphone = cellphone;
            card.Email = email;
            card.Name = fullName;
            card.Phone = phone;
            card.SocialNetwork = socialMedias;
            card.UserID = userId;
            card.Website = website;
            card.Status = EntityStatus.Active;
            card.Photo = avatarBase64;
            card.Skills = _skills.Select(s => new PersonalCardSkill { PersonalCardID = card.ID, SkillID = s.ID }).ToList();

            _personalCardService.Add(card);
        }

        public void UpdatePersonalCard(Guid userId, Guid cardId, string fullName, string address, string address2, string number, string city, string postalCode, string neighborhood, string state, string phone, string cellphone, string email, string website, string socialMedias, string bio, List<string> skills, string avatarBase64, bool status)
        {
            List<Skill> _skills = new List<Skill>();

            foreach (var skill in skills)
                _skills.Add(_skillService.Save(skill));

            var card = GetPersonalCardById(userId, cardId);

            if (card != null)
            {
                card.Address = address;
                card.Address2 = address2;
                card.Bio = bio;
                card.City = city;
                card.Neighborhood = neighborhood;
                card.Number = number;
                card.PostalCode = postalCode;
                card.State = state;
                card.Skills = _skills.Select(s => new PersonalCardSkill { PersonalCardID = card.ID, SkillID = s.ID }).ToList();
                card.Cellphone = cellphone;
                card.Email = email;
                card.Name = fullName;
                card.Phone = phone;
                card.SocialNetwork = socialMedias;
                card.UserID = userId;
                card.Website = website;
                card.Status = status ? EntityStatus.Active : EntityStatus.Inactive;
                card.Photo = avatarBase64;

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
