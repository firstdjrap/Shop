using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using Shop.Services.Interfaces;

namespace Shop.Infrastructure.Business
{
    public class EmployeeAccount : IEmployee
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeAccount(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public bool CreateEmployee(Employee employee)
        {
            var account = employeeRepository.GetByPhone(employee.PhoneNumber);
            if (account != null)
                return false;

            employeeRepository.Add(employee);
            employeeRepository.Save();
            return true;
        }

        public Employee VerifyEmployee(Employee employee)
        {
            return employeeRepository.VerifyEmployee(employee);
        }
    }
}