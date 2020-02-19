using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class DiscountCardRepository : IDiscountCardRepository
    {
        private readonly OrderContext orderContext;

        public DiscountCardRepository(DbContextOptions<OrderContext> connection)
        {
            orderContext = new OrderContext(connection);
        }

        public void Add(DiscountCard discountCard)
        {
            orderContext.DiscountCards.Add(discountCard);
        }

        public void Del(int id)
        {
            DiscountCard discountCard = orderContext.DiscountCards.Find(id);
            if (discountCard != null)
                orderContext.DiscountCards.Remove(discountCard);
        }

        public void Edit(DiscountCard discountCard)
        {
            orderContext.Entry(discountCard).State = EntityState.Modified;
        }

        public DiscountCard Get(int id)
        {
            return orderContext.DiscountCards.Find(id);
        }

        public IEnumerable<DiscountCard> GetList()
        {
            return orderContext.DiscountCards.ToList();
        }

        public void Save()
        {
            orderContext.SaveChanges();
        }
    }
}