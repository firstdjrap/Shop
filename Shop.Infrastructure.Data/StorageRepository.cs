using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class StorageRepository : IStorageRepository
    {
        private readonly ShopContext _shopContext;

        public StorageRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }

        public void Add(Storage storage)
        {
            _shopContext.Storages.Add(storage);
        }

        public void Delete(int id)
        {
            Storage storage = _shopContext.Storages.Find(id);
            if (storage != null)
                _shopContext.Storages.Remove(storage);
        }

        public void Edit(Storage storage)
        {
            _shopContext.Entry(storage).State = EntityState.Modified;
        }

        public Storage GetById(int id)
        {
            return _shopContext.Storages.Find(id);
        }

        public IEnumerable<Storage> GetList()
        {
            return _shopContext.Storages.ToList();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}