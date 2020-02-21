using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly OrderContext _orderContext;

        public DeliveryRepository(DbContextOptions<OrderContext> connection)
        {
            _orderContext = new OrderContext(connection);
        }

        public void Add(Delivery delivery)
        {
            _orderContext.Deliveries.Add(delivery);
        }

        public void Del(int id)
        {
            Delivery delivery = _orderContext.Deliveries.Find(id);
            if (delivery != null)
                _orderContext.Deliveries.Remove(delivery);
        }

        public void Edit(Delivery delivery)
        {
            _orderContext.Entry(delivery).State = EntityState.Modified;
        }

        public Delivery Get(int id)
        {
            return _orderContext.Deliveries.Find(id);
        }

        public IEnumerable<Delivery> GetList()
        {
            return _orderContext.Deliveries.ToList();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }
    }
}