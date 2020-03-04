using Shop.Domain.Core;
using Shop.Domain.Interfaces;

namespace Shop.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopContext _shopContext;

        public OrderRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public void Add(Order order)
        {
            _shopContext.Orders.Add(order);
        }

        public Order GetById(int id)
        {
            return _shopContext.Orders.Find(id);
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}