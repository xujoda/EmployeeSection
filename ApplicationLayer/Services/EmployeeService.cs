using EmployeeSection.ApplicationLayer.Exceptions;
using EmployeeSection.ApplicationLayer.Interfaces;
using EmployeeSection.DomainLayer.Entities;
using EmployeeSection.DomainLayer.Interfaces;

namespace EmployeeSection.ApplicationLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _repository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = _repository.GetAllEmployees();
            return employees ?? throw new EmployeeNotFoundException("Сотрудники не найдены.");
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var employee = _repository.GetEmployeeById(employeeId);
            return employee ?? throw new EmployeeNotFoundException("Сотрудник не найден.");
        }

        public void CreateEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (_repository.IsEmployeeExists(employee.FullName))
            {
                throw new DuplicateEmployeeException("Сотрудник с таким ФИО уже существует.");
            }

            _repository.AddEmployee(employee);
            _repository.SaveChanges();
        }

        public void UpdateEmployee(int employeeId, Employee updatedEmployee)
        {
            if (updatedEmployee == null)
                throw new ArgumentNullException(nameof(updatedEmployee));

            var existingEmployee = _repository.GetEmployeeById(employeeId);

            if (existingEmployee == null)
            {
                throw new EmployeeNotFoundException("Сотрудник не найден.");
            }

            if (!_repository.IsNameUnique(employeeId, updatedEmployee))
            {
                throw new DuplicateEmployeeException("Сотрудник с таким ФИО уже существует.");
            }

            existingEmployee.ChangeFullName(updatedEmployee.FullName);
            existingEmployee.ChangePosition(updatedEmployee.Position);
            
            _repository.UpdateEmployee(existingEmployee);
            _repository.SaveChanges();
        }

        public void DeleteEmployeeById(int employeeId)
        {
            var employee = GetEmployeeById(employeeId);
            if (employee == null)
                throw new EmployeeNotFoundException("Сотрудник не найден.");

            _repository.DeleteEmployee(employee);
            _repository.SaveChanges();
        }
    }
}
