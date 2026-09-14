using System.Threading.Tasks;
using Microsoft.Playwright;
using Framework.Pages;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using Framework.Utils;

namespace Framework.Tests
{
    [TestFixture]

    public class CompletionPage : PageTest
    {
        [Test]
        [Description("Ending the flow by getting a THANK YOU! message and clicking on back home")]

        public async Task CompletionValidation()
        {
            await Page.GotoAsync("https://saucedemo.com");

            var finalLogin = new LoginPage(Page);

            await finalLogin.FullLoginCredentials("standard_user", "secret_sauce");

            var finalInventory = new InventoryPage(Page);

            await finalInventory.AddFirstProductToCart();

            var Finalinfocheck = new InfoCheckoutDetails(Page);

            await Finalinfocheck.FillInformationAndContinue("Adamya", "Tomar", "213451");


             var finalCheckout = new CheckoutCompletePage(Page);

               string successmessage = await finalCheckout.GetSuccessMessage();

               Assert.That(successmessage, Is.EqualTo("Thank you for your order!"));
                
                
                await finalCheckout.ClickBackHome();


               Assert.That(Page.Url, Does.Contain("inventory.html"), "Dashboard navigation failed !");

               var customtime = new FrameworkUtils();

               string time = customtime.GetCustomTimestamp();

              
              Console.WriteLine($"The time is : {time}");

        }

    }

}