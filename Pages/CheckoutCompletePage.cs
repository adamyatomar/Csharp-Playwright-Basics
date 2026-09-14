using System.Threading.Tasks;
using Microsoft.Playwright;
using Framework.Pages;

namespace Framework.Pages
{
    public class CheckoutCompletePage
    {
        private readonly IPage _page;
        private ILocator thank_you;
        private ILocator back_home;

        public CheckoutCompletePage(IPage Page)
        {
            _page = Page;

            thank_you = _page.Locator(".complete-header");

            back_home = _page.Locator("#back-to-products");

        }


        public async Task<string> GetSuccessMessage()
        {
            return await thank_you.TextContentAsync() ?? string.Empty;
        }

        public async Task ClickBackHome()
        {
            await back_home.ClickAsync();

        }
        

    }

}