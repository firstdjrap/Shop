using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly OrderContext orderContext;

        public DeliveryRepository(DbContextOptions<OrderContext> connection)
        {
            orderContext = new OrderContext(connection);
        }

        public void Add(Delivery delivery)
        {
            orderContext.Deliveries.Add(delivery);
        }

        public void Del(int id)
        {
            Delivery delivery = orderContext.Deliveries.Find(id);
            if (delivery != null)
                orderContext.Deliveries.Remove(delivery);
        }

        public void Edit(Delivery delivery)
        {
            orderContext.Entry(delivery).State = EntityState.Modified;
        }

        public Delivery Get(int id)
        {
            return orderContext.Deliveries.Find(id);
        }

        public IEnumerable<Delivery> GetList()
        {
            return orderContext.Deliveries.ToList();
        }

        public void Save()
        {
            orderContext.SaveChanges();
        }
    }
}