using Microsoft.Playwright;

namespace UITests.Api
{
    public class EmployeesApiClient
    {
        private readonly IAPIRequestContext _api;

        public EmployeesApiClient(IAPIRequestContext api)
        {
            _api = api;
        }

        public async Task CreateEmployeeAsync(string name)
        {
            var payload = new
            {
                name = name
            };

            var response = await _api.PostAsync("/api/employees", new()
            {
                DataObject = payload
            });

            Assert.That(response.Ok, Is.True,
                $"Failed to create employee. Status: {response.Status}");
        }
    }
}
