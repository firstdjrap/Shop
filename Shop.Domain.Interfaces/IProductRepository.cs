using Shop.Domain.Core;
using System;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetProductList();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void EditProduct(Product product);
        void DelProdect(Product product);
        void Save();
    }
}