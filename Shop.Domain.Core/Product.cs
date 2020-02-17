using System;

namespace Shop.Domain.Core
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public int RentId { get; set; }
        public Rent Rent { get; set; }
        public int SubsidiaryId { get; set; }
        public BranchOffice BranchOffice { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}