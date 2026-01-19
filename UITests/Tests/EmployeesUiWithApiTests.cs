using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using UITests.Api;

namespace UITests.Tests
{
    public class EmployeesUiWithApiTests : PageTest
    {
        [Test]
        [Ignore("No UI available to validate employees list. Test kept for future UI implementation.")]
        public async Task EmployeeCreatedViaApi_ShouldAppearInUi_NOT_IMPLEMENTED()
        {
            var apiContext = await Playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://localhost:7228",
                IgnoreHTTPSErrors = true
            });

            var employeesApi = new EmployeesApiClient(apiContext);

            var employeeName = "Pedro API";
            await employeesApi.CreateEmployeeAsync(employeeName);

            await Page.GotoAsync("https://localhost:7228");

            await Expect(Page.GetByText(employeeName))
                .ToBeVisibleAsync();
        }

    }
}
