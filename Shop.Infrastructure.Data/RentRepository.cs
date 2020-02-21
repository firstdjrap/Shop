using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class RentRepository : IRentRepository
    {
        private readonly ShopContext shopContext;

        public RentRepository(DbContextOptions<ShopContext> connection)
        {
            shopContext = new ShopContext(connection);
        }

        public void Add(Rent rent)
        {
            shopContext.Rents.Add(rent);
        }

        public void Delete(int id)
        {
            Rent rent = shopContext.Rents.Find(id);
            if (rent != null)
                shopContext.Rents.Remove(rent);
        }

        public void Edit(Rent rent)
        {
            shopContext.Entry(rent).State = EntityState.Modified;
        }

        public Rent Get(int id)
        {
            return shopContext.Rents.Find(id);
        }

        public IEnumerable<Rent> GetList()
        {
            return shopContext.Rents.ToList();
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}