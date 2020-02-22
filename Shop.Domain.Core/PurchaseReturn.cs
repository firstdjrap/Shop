using System;

namespace Shop.Domain.Core
{
    public class PurchaseReturn
    {
        public int Id { get; set; }
        public string Reason { get; set; }

        public Order Order { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}