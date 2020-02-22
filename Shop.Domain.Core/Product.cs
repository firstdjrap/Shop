using System;
using System.Collections.Generic;

namespace Shop.Domain.Core
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }

        public int? BranchOfficeId { get; set; }
        public BranchOffice BranchOffice { get; set; }
        public int? MarkdownId { get; set; }
        public Markdown Markdown { get; set; }
        public int? PromotionId { get; set; }
        public Promotion Promotion { get; set; }
        public int? StorageId { get; set; }
        public Storage Storage { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}