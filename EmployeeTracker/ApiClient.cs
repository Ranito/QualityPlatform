using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmployeeTracker
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri("https://jsonplaceholder.typicode.com/")
            };
        }

        public async Task<UserDto> GetUserAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"users/{userId}");

            response.EnsureSuccessStatusCode();

            var user = await response.Content.ReadFromJsonAsync<UserDto>();
            return user;
        }
    }
}
