using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }

        public void Add(Product product)
        {
            _shopContext.Products.Add(product);
        }

        public void Delete(int id)
        {
            Product product = _shopContext.Products.Find(id);
            if (product != null)
                _shopContext.Products.Remove(product);
        }

        public void Edit(Product product)
        {
            _shopContext.Entry(product).State = EntityState.Modified;
        }

        public Product GetById(int id)
        {
            return _shopContext.Products.Include(x => x.OrderProducts).SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetList()
        {
            return _shopContext.Products.Include(p => p.BranchOffice).Include(p => p.Storage).ToList();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}