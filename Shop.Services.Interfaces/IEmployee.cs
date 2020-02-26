using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Services.Interfaces
{
    public interface IEmployee
    {
        bool CreateEmployee(Employee employee);
        Employee VerifyEmployee(Employee employee);
        IEnumerable<Employee> GetList();
    }
}