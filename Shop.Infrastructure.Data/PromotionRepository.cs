using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly OrderContext _orderContext;

        public PromotionRepository(DbContextOptions<OrderContext> connection)
        {
            _orderContext = new OrderContext(connection);
        }

        public void Add(Promotion promotion)
        {
            _orderContext.Promotions.Add(promotion);
        }

        public void Del(int id)
        {
            Promotion promotion = _orderContext.Promotions.Find(id);
            if (promotion != null)
                _orderContext.Promotions.Remove(promotion);
        }

        public void Edit(Promotion promotion)
        {
            _orderContext.Entry(promotion).State = EntityState.Modified;
        }

        public Promotion Get(int id)
        {
            return _orderContext.Promotions.Find(id);
        }

        public IEnumerable<Promotion> GetList()
        {
            return _orderContext.Promotions.ToList();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }
    }
}