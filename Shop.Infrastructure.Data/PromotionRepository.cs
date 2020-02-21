using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ShopContext shopContext;

        public PromotionRepository(DbContextOptions<ShopContext> connection)
        {
            shopContext = new ShopContext(connection);
        }

        public void Add(Promotion promotion)
        {
            shopContext.Promotions.Add(promotion);
        }

        public void Delete(int id)
        {
            Promotion promotion = shopContext.Promotions.Find(id);
            if (promotion != null)
                shopContext.Promotions.Remove(promotion);
        }

        public void Edit(Promotion promotion)
        {
            shopContext.Entry(promotion).State = EntityState.Modified;
        }

        public Promotion Get(int id)
        {
            return shopContext.Promotions.Find(id);
        }

        public IEnumerable<Promotion> GetList()
        {
            return shopContext.Promotions.ToList();
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}