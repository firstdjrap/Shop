using Shop.Domain.Core;

namespace Shop.Services.Interfaces
{
    public interface IOrder
    {
        void Add(OrderProduct orderProduct);
        Order GetById(int id);
    }
}