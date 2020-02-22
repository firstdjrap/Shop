using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IDeliveryRepository
    {
        void Add(Delivery delivery);
        void Delete(int id);
        void Edit(Delivery delivery);
        Delivery GetById(int id);
        IEnumerable<Delivery> GetList();
        void Save();
    }
}