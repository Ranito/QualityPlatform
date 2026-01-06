using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Text;
using System.Text.Json;

namespace EmployeeApi.IntegrationTests
{
    public class EmployeesApiTests : IClassFixture<EmployeeApiFactory>
    {
        private readonly HttpClient _client;

        public EmployeesApiTests(EmployeeApiFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetEmployees_ShouldReturn200()
        {
            // Act
            var response = await _client.GetAsync("/api/employees");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateEmployee_ShouldPersistAndReturnEmployee()
        {
            // Arrange
            var employee = new
            {
                name = "Charlie",
                monthlySalary = 4000
            };

            var content = new StringContent(
                JsonSerializer.Serialize(employee),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            var postResponse = await _client.PostAsync("/api/employees", content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, postResponse.StatusCode);

            var getResponse = await _client.GetAsync("/api/employees");
            var body = await getResponse.Content.ReadAsStringAsync();

            Assert.Contains("Charlie", body);
        }
    }
}
