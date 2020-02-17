using System;
using System.Collections.Generic;

namespace Shop.Domain.Core
{
    public class Rent
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int RentalPeriod { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}