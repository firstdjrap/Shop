using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly ShopContext shopContext;

        public DeliveryRepository(DbContextOptions<ShopContext> connection)
        {
            shopContext = new ShopContext(connection);
        }

        public void Add(Delivery delivery)
        {
            shopContext.Deliveries.Add(delivery);
        }

        public void Delete(int id)
        {
            Delivery delivery = shopContext.Deliveries.Find(id);
            if (delivery != null)
                shopContext.Deliveries.Remove(delivery);
        }

        public void Edit(Delivery delivery)
        {
            shopContext.Entry(delivery).State = EntityState.Modified;
        }

        public Delivery Get(int id)
        {
            return shopContext.Deliveries.Find(id);
        }

        public IEnumerable<Delivery> GetList()
        {
            return shopContext.Deliveries.ToList();
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}