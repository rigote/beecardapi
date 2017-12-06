using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using System;
using System.Collections.Generic;

namespace BeeCard.Application.Interfaces
{
    public interface IPlanAppService
    {
        Tuple<long, List<Plan>> GetPlans(int? page, int? size);
        Plan GetPlanById(Guid planId);
        void CreatePlan(string name, string description);
        void UpdatePlan(Guid planID, string name, string description, EntityStatus status);
        void RemovePlan(Guid planId);

    }
}
