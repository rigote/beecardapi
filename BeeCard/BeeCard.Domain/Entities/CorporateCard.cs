using System;

namespace BeeCard.Domain.Entities
{
    public class CorporateCard : BaseCardEntity
    {
        public string Occupation { get; set; }
        public string Department { get; set; }
        public Guid CompanyID { get; set; }
        public Guid UserID { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
    }
}
