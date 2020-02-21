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

        public bool VerifyEmployee(Employee employee)
        {
            var account = employeeRepository.VerifyEmployee(employee);
            if (account == null)
                return false;

            return true;
        }
    }
}