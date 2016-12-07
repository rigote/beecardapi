namespace BeeCard.Domain.Entities
{
    public class BaseCardEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }
    }
}
