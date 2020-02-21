using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class RentRepository : IRentRepository
    {
        private readonly OrderContext _orderContext;

        public RentRepository(DbContextOptions<OrderContext> connection)
        {
            _orderContext = new OrderContext(connection);
        }

        public void Add(Rent rent)
        {
            _orderContext.Rents.Add(rent);
        }

        public void Del(int id)
        {
            Rent rent = _orderContext.Rents.Find(id);
            if (rent != null)
                _orderContext.Rents.Remove(rent);
        }

        public void Edit(Rent rent)
        {
            _orderContext.Entry(rent).State = EntityState.Modified;
        }

        public Rent Get(int id)
        {
            return _orderContext.Rents.Find(id);
        }

        public IEnumerable<Rent> GetList()
        {
            return _orderContext.Rents.ToList();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }
    }
}