using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly ShopContext shopContext;

        public ClientRepository(DbContextOptions<ShopContext> connection)
        {
            shopContext = new ShopContext(connection);
        }

        public void Add(Client client)
        {
            shopContext.Clients.Add(client);
        }

        public void Delete(int id)
        {
            Client client = shopContext.Clients.Find(id);
            if (client != null)
                shopContext.Clients.Remove(client);
        }

        public void Edit(Client client)
        {
            shopContext.Entry(client).State = EntityState.Modified;
        }

        public Client Get(int id)
        {
            return shopContext.Clients.Find(id);
        }

        public IEnumerable<Client> GetList()
        {
            return shopContext.Clients.ToList();
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}