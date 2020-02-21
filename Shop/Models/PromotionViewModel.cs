using System;

namespace Shop.Models
{
    public class PromotionViewModel
    {
        public int Id { get; set; }
        public int Percent { get; set; }
        public int LifeTime { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}