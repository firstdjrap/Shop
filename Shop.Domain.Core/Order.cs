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

        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public int? PurchaseReturnId { get; set; }
        public PurchaseReturn PurchaseReturn { get; set; }
        public Rent Rent { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}