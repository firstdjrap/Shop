using System;
using System.Collections.Generic;

namespace Shop.Domain.Core
{
    public class PurchaseReturn
    {
        public int Id { get; set; }

        public ICollection<Product> Products { get; set; }
        public string Reason { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}