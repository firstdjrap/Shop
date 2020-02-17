using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DelProdect(int id);
        void EditProduct(Product product);
        Product GetProduct(int id);
        IEnumerable<Product> GetProductList();
        void Save();
    }
}