using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly OrderContext orderContext;

        public ClientRepository(DbContextOptions<OrderContext> connection)
        {
            orderContext = new OrderContext(connection);
        }

        public void Add(Client client)
        {
            orderContext.Clients.Add(client);
        }

        public void Del(int id)
        {
            Client client = orderContext.Clients.Find(id);
            if (client != null)
                orderContext.Clients.Remove(client);
        }

        public void Edit(Client client)
        {
            orderContext.Entry(client).State = EntityState.Modified;
        }

        public Client Get(int id)
        {
            return orderContext.Clients.Find(id);
        }

        public IEnumerable<Client> GetList()
        {
            return orderContext.Clients.ToList();
        }

        public void Save()
        {
            orderContext.SaveChanges();
        }
    }
}