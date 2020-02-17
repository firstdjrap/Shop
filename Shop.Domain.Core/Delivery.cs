using System;
using System.Collections.Generic;

namespace Shop.Domain.Core
{
    public class Delivery
    {
        public int Id { get; set; }

        public ICollection<Product> Products { get; set; }
        public int SubsidiaryId { get; set; }
        public Subsidiary Subsidiary { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
        public string WhereTo { get; set; }
        public DateTime Period { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}