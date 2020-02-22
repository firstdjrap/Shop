using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class DiscountCardRepository : IDiscountCardRepository
    {
        private readonly ShopContext _shopContext;

        public DiscountCardRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }

        public void Add(DiscountCard discountCard)
        {
            _shopContext.DiscountCards.Add(discountCard);
        }

        public void Delete(int id)
        {
            DiscountCard discountCard = _shopContext.DiscountCards.Find(id);
            if (discountCard != null)
                _shopContext.DiscountCards.Remove(discountCard);
        }

        public void Edit(DiscountCard discountCard)
        {
            _shopContext.Entry(discountCard).State = EntityState.Modified;
        }

        public DiscountCard GetById(int id)
        {
            return _shopContext.DiscountCards.Find(id);
        }

        public IEnumerable<DiscountCard> GetList()
        {
            return _shopContext.DiscountCards.ToList();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}