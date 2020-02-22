using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Delete(int id);
        void Edit(Employee employee);
        Employee VerifyEmployee(Employee employee);
        Employee GetById(int id);
        Employee GetByPhone(int phoneNumber);
        IEnumerable<Employee> GetList();
        void Save();
    }
}