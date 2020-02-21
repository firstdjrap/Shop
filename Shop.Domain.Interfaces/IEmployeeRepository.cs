using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee product);
        void Delete(int id);
        void Edit(Employee product);
        Employee VerifyEmployee(Employee product);
        Employee GetById(int id);
        Employee GetByPhone(int phoneNumber);
        IEnumerable<Employee> GetList();
        void Save();
    }
}