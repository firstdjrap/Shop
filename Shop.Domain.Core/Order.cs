using System;
using System.Collections.Generic;

namespace Shop.Domain.Core
{
    public class Order
    {
        public int Id { get; set; }

        public string Status { get; set; }
        public int Price { get; set; }
        public int PaymentMethod { get; set; }
        public string Address { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}