namespace EmployeeSection.DomainLayer.Entities
{
    public class Employee
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Position { get; private set; }

        public Employee(string fullName, string position)
        {
            if (string.IsNullOrEmpty(fullName))
                throw new ArgumentNullException(nameof(fullName));

            if (string.IsNullOrEmpty(position))
                throw new ArgumentNullException(nameof(position));

            Id = 0;
            FullName = fullName;
            Position = position;
        }

        public void ChangePosition(string newPosition)
        {
            if (string.IsNullOrEmpty(newPosition))
                throw new ArgumentNullException(nameof(newPosition));

            Position = newPosition;
        }

        public void ChangeFullName(string newName)
        {
            if (string.IsNullOrEmpty(newName)) 
                throw new ArgumentNullException(nameof(newName));

            FullName = newName;
        }
    }

}
