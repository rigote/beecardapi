namespace BeeCard.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public Country()
        {
            Name = string.Empty;
        }
    }
}
