using System;

namespace Shop.Domain.Core
{
    public class DiscountCard
    {
        public int Id { get; set; }

        public int Number { get; set; }
        public int Percent { get; set; }
        public int LifeTime { get; set; }

        public Client Client { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}