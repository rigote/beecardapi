using System.Collections.Generic;

namespace BeeCard.API.Models
{
    public class CollectionModel<T> where T : class, new()
    {
        public List<T> Items { get; set; }
        public long Total { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

        public CollectionModel()
        {
            Items = new List<T>();
        }
    }
}