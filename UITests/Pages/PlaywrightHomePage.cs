using Microsoft.Playwright;

namespace UITests.Pages
{
    public class PlaywrightHomePage
    {
        private readonly IPage _page;

        public PlaywrightHomePage(IPage page)
        {
            _page = page;
        }

        private ILocator GetStartedLink => _page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        public async Task GoToAsync()
        {
            await _page.GotoAsync("https://playwright.dev");
        }

        public async Task ClickGetStartedAsync()
        {
            await GetStartedLink.ClickAsync();
        }
    }
}
