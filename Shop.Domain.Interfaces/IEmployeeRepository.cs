using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee product);
        void Del(int id);
        void Edit(Employee product);
        Employee Get(int id);
        IEnumerable<Employee> GetList();
        void Save();
    }
}