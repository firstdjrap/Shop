using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ShopContext _shopContext;

        public DeliveryRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }

        public void Add(Delivery delivery)
        {
            _shopContext.Deliveries.Add(delivery);
        }

        public void Delete(int id)
        {
            Delivery delivery = _shopContext.Deliveries.Find(id);
            if (delivery != null)
                _shopContext.Deliveries.Remove(delivery);
        }

        public void Edit(Delivery delivery)
        {
            _shopContext.Entry(delivery).State = EntityState.Modified;
        }

        public Delivery GetById(int id)
        {
            return _shopContext.Deliveries.Find(id);
        }

        public IEnumerable<Delivery> GetList()
        {
            return _shopContext.Deliveries.ToList();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}