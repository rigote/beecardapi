using System;

namespace BeeCard.Domain.Entities
{
    public class PersonalCard : BaseCardEntity
    {        
        public string Address { get; set; }
        public string Website { get; set; }        
        public string SocialNetwork { get; set; }
        public Guid UserID { get; set; }

        public virtual User User { get; set; }
    }
}
