using Shop.Domain.Core;

namespace Shop.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order GetById(int id);
        void Save();
    }
}