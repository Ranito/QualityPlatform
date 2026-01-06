using System;
using System.Threading.Tasks;

namespace EmployeeTracker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Calling external API...");

            var apiClient = new ApiClient();
            var user = await apiClient.GetUserAsync(1);

            Console.WriteLine($"User: {user.Name} ({user.Email})");
        }
    }
}
