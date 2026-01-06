using System;
using System.Threading.Tasks;

namespace EmployeeTracker
{
    public class AsyncDemoService
    {
        public async Task<string> GetMessageAsync()
        {
            await Task.Delay(2000);
            return "Async operation completed";
        }
    }
}
