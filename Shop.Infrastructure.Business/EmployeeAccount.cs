using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using Shop.Services.Interfaces;

namespace Shop.Infrastructure.Business
{
    public class EmployeeAccount : IEmployee
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeAccount(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool CreateEmployee(Employee employee)
        {
            var account = _employeeRepository.GetByPhone(employee.PhoneNumber);
            if (account != null)
                return false;

            _employeeRepository.Add(employee);
            _employeeRepository.Save();
            return true;
        }

        public Employee VerifyEmployee(Employee employee)
        {
            return _employeeRepository.VerifyEmployee(employee);
        }
    }
}