using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class StorageRepository : IStorageRepository
    {
        private readonly ShopContext shopContext;

        public StorageRepository(DbContextOptions<ShopContext> connection)
        {
            shopContext = new ShopContext(connection);
        }

        public void Add(Storage storage)
        {
            shopContext.Storages.Add(storage);
        }

        public void Delete(int id)
        {
            Storage storage = shopContext.Storages.Find(id);
            if (storage != null)
                shopContext.Storages.Remove(storage);
        }

        public void Edit(Storage storage)
        {
            shopContext.Entry(storage).State = EntityState.Modified;
        }

        public Storage Get(int id)
        {
            return shopContext.Storages.Find(id);
        }

        public IEnumerable<Storage> GetList()
        {
            return shopContext.Storages.ToList();
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}