namespace EmployeeTracker
{
    public class Contractor : Employee
    {
        public decimal HourlyRate { get; }
        public int HoursPerMonth { get; }

        public Contractor(string name, decimal hourlyRate, int hoursPerMonth)
            : base(name)
        {
            HourlyRate = hourlyRate;
            HoursPerMonth = hoursPerMonth;
        }

        public override decimal CalculateMonthlySalary()
        {
            return HourlyRate * HoursPerMonth;
        }
    }
}
