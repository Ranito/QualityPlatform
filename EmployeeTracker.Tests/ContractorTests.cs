using EmployeeTracker;
using Xunit;

namespace EmployeeTracker.Tests
{
    public class ContractorTests
    {
        [Fact]
        public void CalculateMonthlySalary_ShouldReturnHourlyRateTimesHours()
        {
            // Arrange
            var contractor = new Contractor("Bob", 50, 160);

            // Act
            var monthlySalary = contractor.CalculateMonthlySalary();

            // Assert
            Assert.Equal(8000, monthlySalary);
        }
    }
}
