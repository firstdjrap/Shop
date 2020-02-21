using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly OrderContext _orderContext;

        public EmployeeRepository(DbContextOptions<OrderContext> connection)
        {
            _orderContext = new OrderContext(connection);
        }

        public void Add(Employee employee)
        {
            _orderContext.Employees.Add(employee);
        }

        public void Del(int id)
        {
            Employee employee = _orderContext.Employees.Find(id);
            if (employee != null)
                _orderContext.Employees.Remove(employee);
        }

        public void Edit(Employee employee)
        {
            _orderContext.Entry(employee).State = EntityState.Modified;
        }

        public Employee Get(int id)
        {
            return _orderContext.Employees.Find(id);
        }

        public IEnumerable<Employee> GetList()
        {
            return _orderContext.Employees.ToList();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }
    }
}