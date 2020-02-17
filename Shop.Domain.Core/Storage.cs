using System;
using System.Collections.Generic;

namespace Shop.Domain.Core
{
    public class Storage
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int ResponsibleId { get; set; }
        public Employee Employee { get; set; }

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Rent> Rents { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}