using EmployeeSection.DomainLayer.Entities;

namespace EmployeeSection.ApplicationLayer.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int employeeId);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(int employeeId, Employee employee);
        void DeleteEmployeeById(int employeeId);
    }
}
