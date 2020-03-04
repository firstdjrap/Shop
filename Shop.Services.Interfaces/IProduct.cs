using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Services.Interfaces
{
    public interface IProduct
    {
        void Add(Product product);
        void Delete(int id);
        void Edit(Product product);
        Product GetById(int id);
        IEnumerable<Product> GetList();
    }
}