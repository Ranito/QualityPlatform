using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace UITests.Base
{
    public abstract class UiTestBase : PageTest
    {
        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1280,
                    Height = 800
                }
            };
        }
    }

}
