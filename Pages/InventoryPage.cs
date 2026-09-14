using System.Threading.Tasks;
using Microsoft.Playwright;
using Framework.Pages;

namespace Framework.Pages
{
    public class InventoryPage
    {
        private readonly IPage _page;
        private ILocator _add_to_cart;
        private ILocator _shopping_cart;

         private ILocator _checkout_button;


        public InventoryPage(IPage Page)
        {
            _page = Page;

              _add_to_cart = _page.Locator("#add-to-cart-sauce-labs-backpack");

               _shopping_cart = _page.Locator(".shopping_cart_link");

               _checkout_button = _page.GetByRole(AriaRole.Button, new() { Name = "Checkout" });


        }

        public async Task AddFirstProductToCart()
        {
            await _add_to_cart.ClickAsync();

            await _shopping_cart.ClickAsync();

            await _checkout_button.ClickAsync();

        }

    }    


}