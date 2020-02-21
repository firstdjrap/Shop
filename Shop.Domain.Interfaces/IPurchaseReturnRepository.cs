using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IPurchaseReturnRepository
    {
        void Add(PurchaseReturn product);
        void Delete(int id);
        void Edit(PurchaseReturn product);
        PurchaseReturn Get(int id);
        IEnumerable<PurchaseReturn> GetList();
        void Save();
    }
}