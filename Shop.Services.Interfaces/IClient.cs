using Shop.Domain.Core;

namespace Shop.Services.Interfaces
{
    public interface IClient
    {
        bool CreateEmployee(Client client);
        Client VerifyEmployee(Client client);
        bool AddDiscountCard(int id, string number);
    }
}