using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IClientRepository
    {
        void Add(Client product);
        void Del(int id);
        void Edit(Client product);
        Client Get(int id);
        IEnumerable<Client> GetList();
        void Save();
    }
}