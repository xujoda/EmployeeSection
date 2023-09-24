using EmployeeSection.DomainLayer.Entities;

namespace EmployeeSection.DomainLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        bool IsEmployeeExists(string fullName);
        bool IsNameUnique(int id, Employee employee);
        void SaveChanges();
    }
}
