using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ShopContext _shopContext;

        public EmployeeRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }

        public void Add(Employee employee)
        {
            _shopContext.Employees.Add(employee);
        }

        public void Delete(int id)
        {
            Employee employee = _shopContext.Employees.Find(id);
            if (employee != null)
                _shopContext.Employees.Remove(employee);
        }

        public void Edit(Employee employee)
        {
            _shopContext.Entry(employee).State = EntityState.Modified;
        }

        public Employee VerifyEmployee(Employee employee)
        {
            return _shopContext.Employees.FirstOrDefault(e => e.PhoneNumber == employee.PhoneNumber && e.Password == employee.Password);
        }

        public Employee GetById(int id)
        {
            return _shopContext.Employees.Find(id);
        }

        public Employee GetByPhone(int phoneNumber)
        {
            return _shopContext.Employees.FirstOrDefault(e => e.PhoneNumber == phoneNumber);
        }

        public IEnumerable<Employee> GetList()
        {
            return _shopContext.Employees.ToList();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}