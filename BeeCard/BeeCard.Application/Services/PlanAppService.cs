using BeeCard.Application.Interfaces;
using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using BeeCard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeCard.Application.Services
{
    public class PlanAppService : IPlanAppService
    {
        private readonly IPlanService _planService;

        public PlanAppService(IPlanService planService)
        {
            _planService = planService;
        }

        public virtual Tuple<long, List<Plan>> GetPlans(int? page, int? size)
        {
            return _planService.Find(page, size, o => o.ID, c => c.Status != EntityStatus.Deleted);
        }
        
        public virtual Plan GetPlanById(Guid planId)
        {
            Guid _id;
            if (Guid.TryParse(string.Format("{0}", planId), out _id))
                return _planService.Find(null, null, null, c => c.ID == _id && c.Status != EntityStatus.Deleted).Item2.FirstOrDefault();
            else
                throw new ArgumentException(string.Empty, "Invalid data");
        }
        
        public virtual void CreatePlan(string name, string description)
        {
            var plan = _planService.Find(null, null, null, c => c.Name.Contains(name)).Item2.FirstOrDefault();

            if (plan == null)
            {
                plan = new Plan() { Name = name, Description = description, Status = EntityStatus.Pending };
                _planService.Add(plan);
            }
            else
                throw new ArgumentException(string.Empty, "Plan already exists");
        }

        public virtual void UpdatePlan(Guid planID, string name, string description, EntityStatus status)
        {
            var plan = GetPlanById(planID);

            if (plan != null && plan.ID == planID)
            {
                plan.Name = name;
                plan.Description = description;
                plan.Status = status;
                _planService.Update(plan);
            }

        }

        public virtual void RemovePlan(Guid planId)
        {
            var plan = GetPlanById(planId);

            if (plan != null && plan.ID == planId)
                _planService.Remove(plan);
            else
                throw new ArgumentException(string.Empty, "NotFound");
        }
    }
}
