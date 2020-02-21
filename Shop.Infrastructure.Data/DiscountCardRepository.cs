using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class DiscountCardRepository : IDiscountCardRepository
    {
        private readonly ShopContext shopContext;

        public DiscountCardRepository(DbContextOptions<ShopContext> connection)
        {
            shopContext = new ShopContext(connection);
        }

        public void Add(DiscountCard discountCard)
        {
            shopContext.DiscountCards.Add(discountCard);
        }

        public void Delete(int id)
        {
            DiscountCard discountCard = shopContext.DiscountCards.Find(id);
            if (discountCard != null)
                shopContext.DiscountCards.Remove(discountCard);
        }

        public void Edit(DiscountCard discountCard)
        {
            shopContext.Entry(discountCard).State = EntityState.Modified;
        }

        public DiscountCard Get(int id)
        {
            return shopContext.DiscountCards.Find(id);
        }

        public IEnumerable<DiscountCard> GetList()
        {
            return shopContext.DiscountCards.ToList();
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}