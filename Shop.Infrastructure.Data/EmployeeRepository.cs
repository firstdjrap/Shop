using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly OrderContext orderContext;

        public EmployeeRepository(DbContextOptions<OrderContext> connection)
        {
            orderContext = new OrderContext(connection);
        }

        public void Add(Employee employee)
        {
            orderContext.Employees.Add(employee);
        }

        public void Del(int id)
        {
            Employee employee = orderContext.Employees.Find(id);
            if (employee != null)
                orderContext.Employees.Remove(employee);
        }

        public void Edit(Employee employee)
        {
            orderContext.Entry(employee).State = EntityState.Modified;
        }

        public Employee Get(int id)
        {
            return orderContext.Employees.Find(id);
        }

        public IEnumerable<Employee> GetList()
        {
            return orderContext.Employees.ToList();
        }

        public void Save()
        {
            orderContext.SaveChanges();
        }
    }
}