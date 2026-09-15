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

    public class CompletionTests : PageTest
    {
        
       public static IEnumerable<TestCaseData> LoginDataSource()
        {
            
            List<LoginDataModel> allDatas = JsonReader.GetLoginData();

            foreach(var data in allDatas)
            {
                yield return new TestCaseData(data.Username.ToString(), data.Password.ToString()).SetName(data.Description);

            }

        }

         [Test]
         [TestCaseSource(nameof(LoginDataSource))]

         public async Task CompleteValidation(string user, string pass)
        {
            await Page.GotoAsync("https://www.saucedemo.com");

            var finalLogin = new LoginPage(Page);

            await finalLogin.FullLoginCredentials(user, pass);

            if(user == "standard_user")
            {
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

            else
            {
                ILocator errorbox = Page.GetByTestId("error");

                string errorText = await errorbox.TextContentAsync() ?? string.Empty;

                Assert.That(errorText, Does.Contain("locked out"), "CRITICAL FAILURE: Locked out user error box was not displayed on the screen!");

                Console.WriteLine("Negative flow verification passed successfully for locked out user profile!");



            }

            

        }


    }



    
}