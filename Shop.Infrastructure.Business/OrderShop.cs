using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using Shop.Services.Interfaces;
using System;

namespace Shop.Infrastructure.Business
{
    public class OrderShop : IOrder
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;

        public OrderShop(IOrderRepository orderRepository, IProductRepository productRepository, IClientRepository clientRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _clientRepository = clientRepository;
        }

        public void Add(OrderProduct orderProduct)
        {
            var product = _productRepository.GetById(orderProduct.ProductId);

            int id = 1;//TODO: добавить выборку из куков id клиента
            var client = _clientRepository.GetById(id);

            string address = orderProduct.Order.Address;
            if (client != null && orderProduct.Order.Address == null)
                address = client.Address;
            else if (client == null)
                return;


            var order = new Order
            {
                Status = "На проверке",
                Price = product.Price,
                Address = address,
                ClientId = id,
                CreatedAt = DateTime.Now
            };

            _orderRepository.Add(order);
            _orderRepository.Save();

            product.OrderProducts.Add(new OrderProduct { OrderId = order.Id, ProductId = product.Id });

            _productRepository.Save();
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
