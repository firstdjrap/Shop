using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IStorageRepository
    {
        void Add(Storage storage);
        void Delete(int id);
        void Edit(Storage storage);
        Storage GetById(int id);
        IEnumerable<Storage> GetList();
        void Save();
    }
}