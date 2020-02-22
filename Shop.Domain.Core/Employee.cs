using System;

namespace Shop.Domain.Core
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }

        public int? BranchOfficeId { get; set; }
        public BranchOffice BranchOffice { get; set; }
        public int? StorageId { get; set; }
        public Storage Storage { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}