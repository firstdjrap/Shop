using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IRentRepository
    {
        void Add(Rent rent);
        void Delete(int id);
        void Edit(Rent rent);
        Rent GetById(int id);
        IEnumerable<Rent> GetList();
        void Save();
    }
}