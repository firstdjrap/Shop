using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class RentRepository : IRentRepository
    {
        private readonly ShopContext _shopContext;

        public RentRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }

        public void Add(Rent rent)
        {
            _shopContext.Rents.Add(rent);
        }

        public void Delete(int id)
        {
            Rent rent = _shopContext.Rents.Find(id);
            if (rent != null)
                _shopContext.Rents.Remove(rent);
        }

        public void Edit(Rent rent)
        {
            _shopContext.Entry(rent).State = EntityState.Modified;
        }

        public Rent GetById(int id)
        {
            return _shopContext.Rents.Find(id);
        }

        public IEnumerable<Rent> GetList()
        {
            return _shopContext.Rents.ToList();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}