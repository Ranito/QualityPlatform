namespace EmployeeApi.Models
{
    public class Employee
    {
        public int Id { get; set; }   // PK automática
        public string Name { get; set; }
        public decimal MonthlySalary { get; set; }
    }
}
