using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class PurchaseReturnRepository : IPurchaseReturnRepository
    {
        private readonly ShopContext shopContext;

        public PurchaseReturnRepository(DbContextOptions<ShopContext> connection)
        {
            shopContext = new ShopContext(connection);
        }

        public void Add(PurchaseReturn purchaseReturn)
        {
            shopContext.PurchaseReturns.Add(purchaseReturn);
        }

        public void Delete(int id)
        {
            PurchaseReturn purchaseReturn = shopContext.PurchaseReturns.Find(id);
            if (purchaseReturn != null)
                shopContext.PurchaseReturns.Remove(purchaseReturn);
        }

        public void Edit(PurchaseReturn purchaseReturn)
        {
            shopContext.Entry(purchaseReturn).State = EntityState.Modified;
        }

        public PurchaseReturn Get(int id)
        {
            return shopContext.PurchaseReturns.Find(id);
        }

        public IEnumerable<PurchaseReturn> GetList()
        {
            return shopContext.PurchaseReturns.ToList();
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}