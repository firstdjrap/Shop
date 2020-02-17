using Shop.Domain.Core;
using Shop.Services.Interfaces;

namespace Shop.Infrastructure.Business
{
    public class CacheOrder : IOrder
    {
        public void MakeOrder(Product product)
        {
            // код покупки книги при оплате наличностью
        }
    }
}