using System.Threading.Tasks;
using Framework.Data;
using Framework.Pages;
using Framework.Tests;
using Framework.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Playwright.NUnit;

namespace Framework.Tests
{
    [TestFixture]
    public class ValidUserTests : PageTest
    {
        public static IEnumerable<TestCaseData> ValidUserDataSource()
        {
            List<LoginDataModel> allData = JsonReader.GetLoginData();

            var data = allData[0];

            yield return new TestCaseData(data.Username, data.Password).SetName(data.Description);
            

        }


        [Test]
        [TestCaseSource(nameof(ValidUserDataSource))]
        [Description("Verified positive user journey ending with order completion")]

        public async Task PositiveEndToEndCheckout(string user, string pass)
        {
            
            await Page.GotoAsync("https://www.saucedemo.com");

            var finalLogin = new LoginPage(Page);

            await finalLogin.FullLoginCredentials(user, pass);

            var finalInventory = new InventoryPage(Page);

            await finalInventory.AddFirstProductToCart();

            var finalInfoCheck = new InfoCheckoutDetails(Page);

            await finalInfoCheck.FillInformationAndContinue("Adamya", "Tomar", "213451");

            var finalCheckout = new CheckoutCompletePage(Page);

            string successMessage = await finalCheckout.GetSuccessMessage();

            Assert.That(successMessage, Does.Contain("Thank you for your order!"));

            await finalCheckout.ClickBackHome();

            Assert.That(Page.Url, Does.Contain("inventory.html"), "CRITICAL FAILURE : Dashboard navigation failed!!");

            var customtime = new FrameworkUtils();

            string time = customtime.GetCustomTimestamp();

            Console.WriteLine($"[Postive Test Log] The execution time is : {time}");

            
        }



    }

}