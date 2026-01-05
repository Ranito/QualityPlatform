namespace EmployeeTracker
{
    public interface IEmployee
    {
        string Name { get; }
        decimal CalculateMonthlySalary();
    }
}
