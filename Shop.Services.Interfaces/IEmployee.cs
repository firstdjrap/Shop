using Shop.Domain.Core;

namespace Shop.Services.Interfaces
{
    public interface IEmployee
    {
        bool CreateEmployee(Employee employee);
        Employee VerifyEmployee(Employee employee);
    }
}