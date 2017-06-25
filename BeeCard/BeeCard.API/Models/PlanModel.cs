using BeeCard.Domain.Entities;
using BeeCard.Domain.Entities.Enum;
using System;

namespace BeeCard.API.Models
{
    public class BasePlanModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
    }

    public class RequestPlanModel : BasePlanModel { }

    public class ResponsePlanModel : BasePlanModel
    {
        public ResponsePlanModel(Plan plan)
        {
            Id = plan.ID;
            Name = plan.Name;
            Description = plan.Description;
            Status = plan.Status;
        }
    }
}