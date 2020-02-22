using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ShopContext _shopContext;

        public PromotionRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }

        public void Add(Promotion promotion)
        {
            _shopContext.Promotions.Add(promotion);
        }

        public void Delete(int id)
        {
            Promotion promotion = _shopContext.Promotions.Find(id);
            if (promotion != null)
                _shopContext.Promotions.Remove(promotion);
        }

        public void Edit(Promotion promotion)
        {
            _shopContext.Entry(promotion).State = EntityState.Modified;
        }

        public Promotion GetById(int id)
        {
            return _shopContext.Promotions.Find(id);
        }

        public IEnumerable<Promotion> GetList()
        {
            return _shopContext.Promotions.ToList();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}