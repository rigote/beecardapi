using System;
using System.Linq;
using System.Collections.Generic;
using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using BeeCard.Domain.Interfaces.Services;

namespace BeeCard.Application.Services
{
    public class SubscriptionHistoryAppService : ISubscriptionHistoryAppService
    {
        private readonly ISubscriptionHistoryService _subscriptionHistoryService;

        public SubscriptionHistoryAppService(ISubscriptionHistoryService subscriptionHistoryService)
        {
            _subscriptionHistoryService = subscriptionHistoryService;
        }

        public void CreateSubscriptionHistory(Guid companyId, SubscriptionType subscriptionType, decimal subscriptionPrice, DateTime subscriptionDate, SubscriptionStatus subscriptionStatus)
        {
            var subscriptionHistory = new SubscriptionHistory();

            subscriptionHistory.CompanyID = companyId;
            subscriptionHistory.Status = EntityStatus.Active;
            subscriptionHistory.SubscriptionDate = subscriptionDate;
            subscriptionHistory.SubscriptionPrice = subscriptionPrice;
            subscriptionHistory.SubscriptionStatus = subscriptionStatus;
            subscriptionHistory.SubscriptionType = subscriptionType;
            
            _subscriptionHistoryService.Add(subscriptionHistory);
        }

        public SubscriptionHistory GetSubscriptionHistoryById(Guid companyId, Guid subscriptionId)
        {
            return _subscriptionHistoryService.Find(c => c.ID == companyId && c.ID == subscriptionId && c.Status != EntityStatus.Deleted).FirstOrDefault();
        }

        public List<SubscriptionHistory> GetAllSubscriptionHistory(Guid companyId)
        {
            return _subscriptionHistoryService.Find(c => c.CompanyID == companyId && c.Status != EntityStatus.Deleted).ToList();
        }
    }
}
