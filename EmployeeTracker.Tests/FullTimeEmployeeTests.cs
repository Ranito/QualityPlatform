using EmployeeTracker;
using Xunit;

namespace EmployeeTracker.Tests
{
    public class FullTimeEmployeeTests
    {
        [Fact]
        public void CalculateMonthlySalary_ShouldReturnAnnualDividedBy12()
        {
            // Arrange
            var employee = new FullTimeEmployee("Alice", 60000);

            // Act
            var monthlySalary = employee.CalculateMonthlySalary();

            // Assert
            Assert.Equal(5000, monthlySalary);
        }
    }
}
