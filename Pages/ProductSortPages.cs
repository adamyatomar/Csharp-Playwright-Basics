using System.Threading.Tasks;
using Framework.Pages;
using Microsoft.Playwright;

namespace Framework.Pages
{

   public class ProductSortPages
    {
        private readonly IPage _page;
        private ILocator Sorted;
        private ILocator Textelement;

        public ProductSortPages(IPage Page)
        {
            _page = Page;

            Sorted = _page.GetByTestId("product-sort-container");

           Textelement = _page.GetByText("Sauce Labs Onesie");

        }

        public async Task SelectSortingOption(string optionValue)
        {
            await Sorted.SelectOptionAsync(optionValue);

        }

        public async Task<string> GetFirstProductTitle()
        {
            return await Textelement.TextContentAsync();

        }

    }  
  


}