using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Services.Interfaces
{
    public interface IStorage
    {
        void Add(Storage storage);
        void Delete(int id);
        void Edit(Storage storage);
        Storage GetById(int id);
        IEnumerable<Storage> GetList();
    }
}