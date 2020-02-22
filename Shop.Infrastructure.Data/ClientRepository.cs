using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly ShopContext _shopContext;

        public ClientRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }

        public void Add(Client client)
        {
            _shopContext.Clients.Add(client);
        }

        public void Delete(int id)
        {
            Client client = _shopContext.Clients.Find(id);
            if (client != null)
                _shopContext.Clients.Remove(client);
        }

        public void Edit(Client client)
        {
            _shopContext.Entry(client).State = EntityState.Modified;
        }

        public Client VerifyEmployee(Client client)
        {
            return _shopContext.Clients.FirstOrDefault(e => e.PhoneNumber == client.PhoneNumber && e.Password == client.Password);
        }

        public Client GetById(int id)
        {
            return _shopContext.Clients.Find(id);
        }

        public Client GetByPhone(int phoneNumber)
        {
            return _shopContext.Clients.FirstOrDefault(e => e.PhoneNumber == phoneNumber);
        }

        public IEnumerable<Client> GetList()
        {
            return _shopContext.Clients.ToList();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}