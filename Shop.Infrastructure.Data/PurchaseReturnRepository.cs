using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class PurchaseReturnRepository : IPurchaseReturnRepository
    {
        private readonly ShopContext _shopContext;

        public PurchaseReturnRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }

        public void Add(PurchaseReturn purchaseReturn)
        {
            _shopContext.PurchaseReturns.Add(purchaseReturn);
        }

        public void Delete(int id)
        {
            PurchaseReturn purchaseReturn = _shopContext.PurchaseReturns.Find(id);
            if (purchaseReturn != null)
                _shopContext.PurchaseReturns.Remove(purchaseReturn);
        }

        public void Edit(PurchaseReturn purchaseReturn)
        {
            _shopContext.Entry(purchaseReturn).State = EntityState.Modified;
        }

        public PurchaseReturn GetById(int id)
        {
            return _shopContext.PurchaseReturns.Find(id);
        }

        public IEnumerable<PurchaseReturn> GetList()
        {
            return _shopContext.PurchaseReturns.ToList();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}