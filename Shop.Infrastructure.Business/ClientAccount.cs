using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using Shop.Services.Interfaces;
using System;

namespace Shop.Infrastructure.Business
{
    public class ClientAccount : IClient
    {
        private readonly IClientRepository _clientRepository;
        private readonly IDiscountCardRepository _discountCardRepository;

        public ClientAccount(IClientRepository clientRepository, IDiscountCardRepository discountCardRepository)
        {
            _clientRepository = clientRepository;
            _discountCardRepository = discountCardRepository;
        }

        public bool CreateEmployee(Client client)
        {
            var account = _clientRepository.GetByPhone(client.PhoneNumber);
            if (account != null)
                return false;

            _clientRepository.Add(client);
            _clientRepository.Save();
            return true;
        }

        public Client VerifyEmployee(Client client)
        {
            return _clientRepository.VerifyEmployee(client);
        }

        public bool AddDiscountCard(int id, string number) 
        {
            var discountCard = _discountCardRepository.GetByNumber(number);
            if (discountCard == null)
                return false;

            var client = _clientRepository.GetByDiscountCard(discountCard.Id);
            if (client != null)
                return false;

            client = _clientRepository.GetById(id);
            client.DiscountCardId = discountCard.Id;

            _clientRepository.Edit(client);
            _clientRepository.Save();

            Console.WriteLine(discountCard);

            return true;
        }
    }
}