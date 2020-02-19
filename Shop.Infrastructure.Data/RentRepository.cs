using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class RentRepository : IRentRepository
    {
        private readonly OrderContext orderContext;

        public RentRepository(DbContextOptions<OrderContext> connection)
        {
            orderContext = new OrderContext(connection);
        }

        public void Add(Rent rent)
        {
            orderContext.Rents.Add(rent);
        }

        public void Del(int id)
        {
            Rent rent = orderContext.Rents.Find(id);
            if (rent != null)
                orderContext.Rents.Remove(rent);
        }

        public void Edit(Rent rent)
        {
            orderContext.Entry(rent).State = EntityState.Modified;
        }

        public Rent Get(int id)
        {
            return orderContext.Rents.Find(id);
        }

        public IEnumerable<Rent> GetList()
        {
            return orderContext.Rents.ToList();
        }

        public void Save()
        {
            orderContext.SaveChanges();
        }
    }
}