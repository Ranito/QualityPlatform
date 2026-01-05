using EmployeeTracker;
using Xunit;

namespace EmployeeTracker.Tests
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void AddEmployee_ShouldAddEmployeeToCollection()
        {
            // Arrange
            var service = new EmployeeService();
            var employee = new FullTimeEmployee("Alice", 60000);

            // Act
            service.AddEmployee(employee);

            // Assert
            Assert.Single(service.GetAll());
        }
    }
}
