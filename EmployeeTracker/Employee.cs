namespace EmployeeTracker
{
    public abstract class Employee : IEmployee
    {
        public string Name { get; protected set; }

        protected Employee(string name)
        {
            Name = name;
        }

        public abstract decimal CalculateMonthlySalary();
    }
}
