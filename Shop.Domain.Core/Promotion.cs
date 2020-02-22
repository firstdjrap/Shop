using System;
using System.Collections.Generic;

namespace Shop.Domain.Core
{
    public class Promotion
    {
        public int Id { get; set; }

        public int Percent { get; set; }
        public int LifeTime { get; set; }

        public ICollection<Product> Products { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}