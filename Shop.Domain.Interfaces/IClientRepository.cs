using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IClientRepository
    {
        void Add(Client client);
        void Delete(int id);
        void Edit(Client client);
        Client VerifyEmployee(Client client);
        Client GetById(int id);
        Client GetByPhone(int phoneNumber);
        IEnumerable<Client> GetList();
        void Save();
    }
}