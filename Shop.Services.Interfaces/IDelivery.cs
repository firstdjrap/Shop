using Shop.Domain.Core;

namespace Shop.Services.Interfaces
{
    public interface IDelivery
    {
        void AcceptDelivery(Delivery delivery);
    }
}