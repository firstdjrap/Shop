﻿using System;
using System.Collections.Generic;

namespace Shop.Domain.Core
{
    public class Storage
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public char PhoneCode { get; set; }
        public int PhoneNumber { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Rent> Rents { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}