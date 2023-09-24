using EmployeeSection.DomainLayer.Entities;
using EmployeeSection.DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSection.DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == employeeId);
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _context.Employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _context.Entry(employee).State = EntityState.Modified;
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee != null)
                _context.Employees.Remove(employee);
        }

        public bool IsEmployeeExists(string fullName)
        {
            return _context.Employees.Any(e => e.FullName == fullName);
        }

        public bool IsNameUnique(int employeeId, Employee employee)
        {
            return !_context.Employees.Any(e => e.Id != employeeId && e.FullName == employee.FullName);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
