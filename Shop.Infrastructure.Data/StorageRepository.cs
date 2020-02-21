using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class StorageRepository : IStorageRepository
    {
        private readonly OrderContext _orderContext;

        public StorageRepository(DbContextOptions<OrderContext> connection)
        {
            _orderContext = new OrderContext(connection);
        }

        public void Add(Storage storage)
        {
            _orderContext.Storages.Add(storage);
        }

        public void Del(int id)
        {
            Storage storage = _orderContext.Storages.Find(id);
            if (storage != null)
                _orderContext.Storages.Remove(storage);
        }

        public void Edit(Storage storage)
        {
            _orderContext.Entry(storage).State = EntityState.Modified;
        }

        public Storage Get(int id)
        {
            return _orderContext.Storages.Find(id);
        }

        public IEnumerable<Storage> GetList()
        {
            return _orderContext.Storages.ToList();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }
    }
}