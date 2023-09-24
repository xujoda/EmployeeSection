
namespace EmployeeSection.ApplicationLayer.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(string message) : base(message) { }
    }

    public class DuplicateEmployeeException : Exception
    {
        public DuplicateEmployeeException(string message) : base(message) { }
    }
}
