using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly OrderContext orderContext;

        public PromotionRepository(DbContextOptions<OrderContext> connection)
        {
            orderContext = new OrderContext(connection);
        }

        public void Add(Promotion promotion)
        {
            orderContext.Promotions.Add(promotion);
        }

        public void Del(int id)
        {
            Promotion promotion = orderContext.Promotions.Find(id);
            if (promotion != null)
                orderContext.Promotions.Remove(promotion);
        }

        public void Edit(Promotion promotion)
        {
            orderContext.Entry(promotion).State = EntityState.Modified;
        }

        public Promotion Get(int id)
        {
            return orderContext.Promotions.Find(id);
        }

        public IEnumerable<Promotion> GetList()
        {
            return orderContext.Promotions.ToList();
        }

        public void Save()
        {
            orderContext.SaveChanges();
        }
    }
}