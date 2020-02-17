using Shop.Domain.Core;

namespace Shop.Services.Interfaces
{
    public interface IOrder
    {
        void MakeOrder(Product product);
    }
}