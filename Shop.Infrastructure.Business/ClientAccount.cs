using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using Shop.Services.Interfaces;

namespace Shop.Infrastructure.Business
{
    public class ClientAccount : IClient
    {
        private readonly IClientRepository _clientRepository;

        public ClientAccount(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
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
    }
}