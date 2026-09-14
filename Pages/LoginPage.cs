using System.Threading.Tasks;
using Microsoft.Playwright;
using Framework.Pages;

namespace Framework.Pages
{
   public class LoginPage
    {
        private readonly IPage _page;
        private ILocator _username_input;
        private ILocator _password_input;
        private ILocator _login_button;

        public LoginPage(IPage Page)
        {
            _page = Page;

            _username_input = _page.GetByPlaceholder("Username");
            _password_input =  _page.GetByPlaceholder("Password");
            _login_button =  _page.Locator("#login-button");
        }

        public async Task FullLoginCredentials(string username, string password)
        {
            await _username_input.FillAsync(username);

            await _password_input.FillAsync(password);

            await _login_button.ClickAsync();

        }
        

    }

}