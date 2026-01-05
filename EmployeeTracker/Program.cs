using System;

namespace EmployeeTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new EmployeeService();

            service.AddEmployee(new FullTimeEmployee("Alice", 60000));
            service.AddEmployee(new Contractor("Bob", 50, 160));

            Console.WriteLine("=== Employees ===");

            foreach (var employee in service.GetAll())
            {
                Console.WriteLine(
                    $"{employee.Name} - Monthly salary: {employee.CalculateMonthlySalary()}"
                );
            }
        }
    }
}
