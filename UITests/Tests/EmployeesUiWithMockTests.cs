using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace UITests.Tests
{
    public class EmployeesUiWithMockTests : PageTest
    {
        [Test]
        [Ignore("No UI available to validate employees list. Test kept for future UI implementation.")]
        public async Task EmployeesPage_ShouldShowMockedEmployees_NOT_IMPLEMENTED()
        {
            await Page.RouteAsync("**/api/employees", async route =>
            {
                await route.FulfillAsync(new()
                {
                    Status = 200,
                    ContentType = "application/json",
                    Body = """
                    [
                      { "id": 1, "name": "Pedro" },
                      { "id": 2, "name": "Ana" }
                    ]
                    """
                });
            });

            await Page.GotoAsync("https://example.com/employees");

            await Expect(Page.GetByText("Pedro")).ToBeVisibleAsync();
            await Expect(Page.GetByText("Ana")).ToBeVisibleAsync();
        }
    }
}