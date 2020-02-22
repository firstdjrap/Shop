using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(int id);
        void Edit(Product product);
        Product GetById(int id);
        IEnumerable<Product> GetList();
        void Save();
    }
}