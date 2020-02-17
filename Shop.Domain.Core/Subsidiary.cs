using System;
using System.Collections.Generic;

namespace Shop.Domain.Core
{
    public class Subsidiary
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int ResponsibleId { get; set; }
        public Personnel Responsible { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Rent> Rents { get; set; }
        public ICollection<Personnel> Personnels { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}