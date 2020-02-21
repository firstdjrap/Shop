using Shop.Domain.Core;

namespace Shop.Services.Interfaces
{
    public interface IEmployee
    {
        bool CreateEmployee(Employee employee);
        bool VerifyEmployee(Employee employee);
    }
}