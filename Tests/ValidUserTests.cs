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
using Microsoft.VisualBasic;

namespace Framework.Tests
{
    [TestFixture]
    public class ValidUserTests : PageTest
    {

        private IBrowserContext _browsercontext = null!;
        private IPage _page = null!;

        [SetUp]

        public async Task ValidUserSetup()
        {
            _browsercontext = await Browser.NewContextAsync();

            await _browsercontext.Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true

           });
                

            _page = await _browsercontext.NewPageAsync();


        }
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
            
            await _page.GotoAsync("https://www.saucedemo.com");

            var finalLogin = new LoginPage(_page);

            await finalLogin.FullLoginCredentials(user, pass);

            var finalInventory = new InventoryPage(_page);

            await finalInventory.AddFirstProductToCart();

            var finalInfoCheck = new InfoCheckoutDetails(_page);

            await finalInfoCheck.FillInformationAndContinue("Adamya", "Tomar", "213451");

            var finalCheckout = new CheckoutCompletePage(_page);

            string successMessage = await finalCheckout.GetSuccessMessage();

            Assert.That(successMessage, Does.Contain("Thank you for your order!"));

            await finalCheckout.ClickBackHome();

            Assert.That(_page.Url, Does.Contain("inventory.html"), "CRITICAL FAILURE : Dashboard navigation failed!!");

            var customtime = new FrameworkUtils();

            string time = customtime.GetCustomTimestamp();

            Console.WriteLine($"[Postive Test Log] The execution time is : {time}");

            
        }

         [TearDown]
         public async Task ValidUserTeardown()
        {

            var customtime = new FrameworkUtils();

            string time = customtime.GetCustomTimestamp();


            await _browsercontext.Tracing.StopAsync(new TracingStopOptions
            {

               Path = $"Traces/trace_ValidUser_{time}.zip" 

            });

            await _browsercontext.CloseAsync();

        }
    }

}