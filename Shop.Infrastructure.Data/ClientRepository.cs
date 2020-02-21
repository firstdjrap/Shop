using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly OrderContext _orderContext;

        public ClientRepository(DbContextOptions<OrderContext> connection)
        {
            _orderContext = new OrderContext(connection);
        }

        public void Add(Client client)
        {
            _orderContext.Clients.Add(client);
        }

        public void Del(int id)
        {
            Client client = _orderContext.Clients.Find(id);
            if (client != null)
                _orderContext.Clients.Remove(client);
        }

        public void Edit(Client client)
        {
            _orderContext.Entry(client).State = EntityState.Modified;
        }

        public Client Get(int id)
        {
            return _orderContext.Clients.Find(id);
        }

        public IEnumerable<Client> GetList()
        {
            return _orderContext.Clients.ToList();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }
    }
}