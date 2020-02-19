using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Del(int id);
        void Edit(Product product);
        Product Get(int id);
        IEnumerable<Product> GetList();
        void Save();
    }
}