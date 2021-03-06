﻿using System;
using System.Collections.Generic;

namespace Shop.Domain.Core
{
    public class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }

        public int DiscountCardId { get; set; }
        public DiscountCard DiscountCard { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}