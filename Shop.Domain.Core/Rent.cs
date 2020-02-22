using System;

namespace Shop.Domain.Core
{
    public class Rent
    {
        public int Id { get; set; }

        public int RentalPeriod { get; set; }

        public int? BranchOfficeId { get; set; }
        public BranchOffice BranchOffice { get; set; }
        public Order Order { get; set; }
        public int? StorageId { get; set; }
        public Storage Storage { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}