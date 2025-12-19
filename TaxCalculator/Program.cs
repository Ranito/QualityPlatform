using System;
using System.Globalization;


namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Tax Calculator ===");

            try
            {
                decimal annualSalary = ReadSalaryFromUser();
                decimal tax = CalculateTax(annualSalary);
                decimal netSalary = annualSalary - tax;

                PrintResult(annualSalary, tax, netSalary);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static decimal ReadSalaryFromUser()
        {
            Console.Write("Enter annual salary: ");
            string input = Console.ReadLine();

            if (!decimal.TryParse(input, out decimal salary))
            {
                throw new ArgumentException("Salary must be a valid number.");
            }

            if (salary <= 0)
            {
                throw new ArgumentException("Salary must be greater than zero.");
            }

            return salary;
        }

        static decimal CalculateTax(decimal salary)
        {
            if (salary <= 20000)
            {
                return salary * 0.10m;
            }
            else if (salary <= 40000)
            {
                return salary * 0.20m;
            }
            else
            {
                return salary * 0.30m;
            }
        }

        static void PrintResult(decimal gross, decimal tax, decimal net)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
            Console.WriteLine();
            Console.WriteLine($"Gross salary: {gross:C}");
            Console.WriteLine($"Tax: {tax:C}");
            Console.WriteLine($"Net salary: {net:C}");
        }
    }
}
