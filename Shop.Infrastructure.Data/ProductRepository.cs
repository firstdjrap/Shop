using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderContext orderContext;

        public ProductRepository(DbContextOptions<OrderContext> connection)
        {
            orderContext = new OrderContext(connection);
        }

        public void Add(Product product)
        {
            orderContext.Products.Add(product);
        }

        public void Del(int id)
        {
            Product product = orderContext.Products.Find(id);
            if (product != null)
                orderContext.Products.Remove(product);
        }

        public void Edit(Product product)
        {
            orderContext.Entry(product).State = EntityState.Modified;
        }

        public Product Get(int id)
        {
            return orderContext.Products.Find(id);
        }

        public IEnumerable<Product> GetList()
        {
            return orderContext.Products.ToList();
        }

        public void Save()
        {
            orderContext.SaveChanges();
        }
    }
}