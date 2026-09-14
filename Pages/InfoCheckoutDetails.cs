using System.Threading.Tasks;
using Microsoft.Playwright;
using Framework.Pages;

namespace Framework.Pages
{
    public class InfoCheckoutDetails
    {
        private readonly IPage _page;
        private ILocator first_name_input;
        private ILocator last_name_input;
        private ILocator zip_code_input;
        private ILocator continue_button;
        
        private ILocator Finish_Button;

        public InfoCheckoutDetails(IPage Page)
        {
            _page = Page;

            first_name_input = _page.Locator("#first-name");
            last_name_input = _page.Locator("#last-name");
            zip_code_input = _page.GetByPlaceholder("Zip/Postal Code");
            continue_button = _page.Locator("#continue");
            Finish_Button = _page.Locator("#finish");

        }

        public async Task FillInformationAndContinue(string fname, string lname, string zpcode)
        {
            await first_name_input.FillAsync(fname);
            await last_name_input.FillAsync(lname);
            await zip_code_input.FillAsync(zpcode);
            await continue_button.ClickAsync();
            await Finish_Button.ClickAsync();

        }
            

        

    }

}