using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext shopContext;

        public ProductRepository(DbContextOptions<ShopContext> connection)
        {
            shopContext = new ShopContext(connection);
        }

        public void Add(Product product)
        {
            shopContext.Products.Add(product);
        }

        public void Delete(int id)
        {
            Product product = shopContext.Products.Find(id);
            if (product != null)
                shopContext.Products.Remove(product);
        }

        public void Edit(Product product)
        {
            shopContext.Entry(product).State = EntityState.Modified;
        }

        public Product Get(int id)
        {
            return shopContext.Products.Find(id);
        }

        public IEnumerable<Product> GetList()
        {
            return shopContext.Products.ToList();
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}