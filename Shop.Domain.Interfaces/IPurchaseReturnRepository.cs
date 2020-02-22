using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IPurchaseReturnRepository
    {
        void Add(PurchaseReturn purchaseReturn);
        void Delete(int id);
        void Edit(PurchaseReturn purchaseReturn);
        PurchaseReturn GetById(int id);
        IEnumerable<PurchaseReturn> GetList();
        void Save();
    }
}