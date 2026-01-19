using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using UITests.Pages;

namespace UITests.Tests
{
    public class PlaywrightHomeTests : PageTest
    {
        [Test]
        public async Task GetStarted_ShouldNavigateToDocs()
        {
            var homePage = new PlaywrightHomePage(Page);

            await homePage.GoToAsync();
            await homePage.ClickGetStartedAsync();

            await Expect(Page).ToHaveURLAsync("https://playwright.dev/docs/intro");

        }
    }
}
