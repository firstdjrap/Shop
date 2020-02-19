using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class PurchaseReturnRepository : IPurchaseReturnRepository
    {
        private readonly OrderContext orderContext;

        public PurchaseReturnRepository(DbContextOptions<OrderContext> connection)
        {
            orderContext = new OrderContext(connection);
        }

        public void Add(PurchaseReturn purchaseReturn)
        {
            orderContext.PurchaseReturns.Add(purchaseReturn);
        }

        public void Del(int id)
        {
            PurchaseReturn purchaseReturn = orderContext.PurchaseReturns.Find(id);
            if (purchaseReturn != null)
                orderContext.PurchaseReturns.Remove(purchaseReturn);
        }

        public void Edit(PurchaseReturn purchaseReturn)
        {
            orderContext.Entry(purchaseReturn).State = EntityState.Modified;
        }

        public PurchaseReturn Get(int id)
        {
            return orderContext.PurchaseReturns.Find(id);
        }

        public IEnumerable<PurchaseReturn> GetList()
        {
            return orderContext.PurchaseReturns.ToList();
        }

        public void Save()
        {
            orderContext.SaveChanges();
        }
    }
}