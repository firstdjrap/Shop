using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class PurchaseReturnRepository : IPurchaseReturnRepository
    {
        private readonly OrderContext _orderContext;

        public PurchaseReturnRepository(DbContextOptions<OrderContext> connection)
        {
            _orderContext = new OrderContext(connection);
        }

        public void Add(PurchaseReturn purchaseReturn)
        {
            _orderContext.PurchaseReturns.Add(purchaseReturn);
        }

        public void Del(int id)
        {
            PurchaseReturn purchaseReturn = _orderContext.PurchaseReturns.Find(id);
            if (purchaseReturn != null)
                _orderContext.PurchaseReturns.Remove(purchaseReturn);
        }

        public void Edit(PurchaseReturn purchaseReturn)
        {
            _orderContext.Entry(purchaseReturn).State = EntityState.Modified;
        }

        public PurchaseReturn Get(int id)
        {
            return _orderContext.PurchaseReturns.Find(id);
        }

        public IEnumerable<PurchaseReturn> GetList()
        {
            return _orderContext.PurchaseReturns.ToList();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }
    }
}