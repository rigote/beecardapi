using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using System;
using System.Collections.Generic;

namespace BeeCard.Application.Interfaces
{
    public interface ISubscriptionHistoryAppService
    {
        Tuple<long, List<SubscriptionHistory>> GetAllSubscriptionHistory(Guid companyId, int? page, int? size);
        SubscriptionHistory GetSubscriptionHistoryById(Guid companyId, Guid subscriptionId);
        void CreateSubscriptionHistory(Guid companyId, SubscriptionType subscriptionType, decimal subscriptionPrice, DateTime subscriptionDate, SubscriptionStatus subscriptionStatus);
    }
}
