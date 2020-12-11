using System;

namespace Infrastructure.Entities
{
    public class Beer
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdate { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }
    }
}