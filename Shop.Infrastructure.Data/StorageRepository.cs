using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class StorageRepository : IStorageRepository
    {
        private readonly OrderContext orderContext;

        public StorageRepository(DbContextOptions<OrderContext> connection)
        {
            orderContext = new OrderContext(connection);
        }

        public void Add(Storage storage)
        {
            orderContext.Storages.Add(storage);
        }

        public void Del(int id)
        {
            Storage storage = orderContext.Storages.Find(id);
            if (storage != null)
                orderContext.Storages.Remove(storage);
        }

        public void Edit(Storage storage)
        {
            orderContext.Entry(storage).State = EntityState.Modified;
        }

        public Storage Get(int id)
        {
            return orderContext.Storages.Find(id);
        }

        public IEnumerable<Storage> GetList()
        {
            return orderContext.Storages.ToList();
        }

        public void Save()
        {
            orderContext.SaveChanges();
        }
    }
}