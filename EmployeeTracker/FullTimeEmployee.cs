namespace EmployeeTracker
{
    public class FullTimeEmployee : Employee
    {
        public decimal AnnualSalary { get; }

        public FullTimeEmployee(string name, decimal annualSalary)
            : base(name)
        {
            AnnualSalary = annualSalary;
        }

        public override decimal CalculateMonthlySalary()
        {
            return AnnualSalary / 12;
        }
    }
}
