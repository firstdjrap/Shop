using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderContext _orderContext;

        public ProductRepository(DbContextOptions<OrderContext> connection)
        {
            _orderContext = new OrderContext(connection);
        }

        public void Add(Product product)
        {
            _orderContext.Products.Add(product);
        }

        public void Del(int id)
        {
            Product product = _orderContext.Products.Find(id);
            if (product != null)
                _orderContext.Products.Remove(product);
        }

        public void Edit(Product product)
        {
            _orderContext.Entry(product).State = EntityState.Modified;
        }

        public Product Get(int id)
        {
            return _orderContext.Products.Find(id);
        }

        public IEnumerable<Product> GetList()
        {
            return _orderContext.Products.ToList();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }
    }
}