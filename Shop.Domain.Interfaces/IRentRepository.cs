using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IRentRepository
    {
        void Add(Rent product);
        void Delete(int id);
        void Edit(Rent product);
        Rent Get(int id);
        IEnumerable<Rent> GetList();
        void Save();
    }
}