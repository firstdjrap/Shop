using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class DiscountCardRepository : IDiscountCardRepository
    {
        private readonly OrderContext _orderContext;

        public DiscountCardRepository(DbContextOptions<OrderContext> connection)
        {
            _orderContext = new OrderContext(connection);
        }

        public void Add(DiscountCard discountCard)
        {
            _orderContext.DiscountCards.Add(discountCard);
        }

        public void Del(int id)
        {
            DiscountCard discountCard = _orderContext.DiscountCards.Find(id);
            if (discountCard != null)
                _orderContext.DiscountCards.Remove(discountCard);
        }

        public void Edit(DiscountCard discountCard)
        {
            _orderContext.Entry(discountCard).State = EntityState.Modified;
        }

        public DiscountCard Get(int id)
        {
            return _orderContext.DiscountCards.Find(id);
        }

        public IEnumerable<DiscountCard> GetList()
        {
            return _orderContext.DiscountCards.ToList();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }
    }
}