using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IStorageRepository
    {
        void Add(Storage product);
        void Delete(int id);
        void Edit(Storage product);
        Storage Get(int id);
        IEnumerable<Storage> GetList();
        void Save();
    }
}