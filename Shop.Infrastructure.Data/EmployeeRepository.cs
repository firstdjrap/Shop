using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ShopContext shopContext;

        public EmployeeRepository(DbContextOptions<ShopContext> connection)
        {
            shopContext = new ShopContext(connection);
        }

        public void Add(Employee employee)
        {
            shopContext.Employees.Add(employee);
        }

        public void Delete(int id)
        {
            Employee employee = shopContext.Employees.Find(id);
            if (employee != null)
                shopContext.Employees.Remove(employee);
        }

        public void Edit(Employee employee)
        {
            shopContext.Entry(employee).State = EntityState.Modified;
        }

        public Employee VerifyEmployee(Employee employee)
        {
            return shopContext.Employees.FirstOrDefault(e => e.PhoneNumber == employee.PhoneNumber && e.Password == employee.Password);
        }

        public Employee GetById(int id)
        {
            return shopContext.Employees.Find(id);
        }

        public Employee GetByPhone(int phoneNumber)
        {
            return shopContext.Employees.FirstOrDefault(e => e.PhoneNumber == phoneNumber);
        }

        public IEnumerable<Employee> GetList()
        {
            return shopContext.Employees.ToList();
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}