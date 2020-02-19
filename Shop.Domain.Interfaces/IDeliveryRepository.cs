using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IDeliveryRepository
    {
        void Add(Delivery product);
        void Del(int id);
        void Edit(Delivery product);
        Delivery Get(int id);
        IEnumerable<Delivery> GetList();
        void Save();
    }
}