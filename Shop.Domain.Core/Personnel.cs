﻿using System;

namespace Shop.Domain.Core
{
    public class Personnel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Post { get; set; }

        public int StorageId { get; set; }
        public Storage Storage { get; set; }
        public int SubsidiaryId { get; set; }
        public Subsidiary Subsidiary { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}