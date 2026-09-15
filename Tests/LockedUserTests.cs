using System.Threading.Tasks;
using Framework.Data;
using Framework.Pages;
using Framework.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Playwright.NUnit;

namespace Framework.Tests
{
    [TestFixture]
    public class LockedUserTests : PageTest
    {
        
        public static IEnumerable<TestCaseData> LockedUserDataSource()
        {
            List<LoginDataModel> allData = JsonReader.GetLoginData();

            
            var data = allData[1];

            yield return new TestCaseData(data.Username, data.Password).SetName(data.Description);
        }

        [Test]
        [TestCaseSource(nameof(LockedUserDataSource))]
        [Description("Verified negative user lockout security error box validation")]
        public async Task Negative_LockedOutUser_Test(string user, string pass)
        {
            await Page.GotoAsync("https://saucedemo.com");

            var finalLogin = new LoginPage(Page);
            await finalLogin.FullLoginCredentials(user, pass);

            
           
          ILocator errorbox = Page.Locator("[data-test='error']");

            string errorText = await errorbox.TextContentAsync() ?? string.Empty;
            
            Assert.That(errorText, Does.Contain("locked out"), 
                "CRITICAL FAILURE: Locked out error message was missing from the UI panel!");
                
            Console.WriteLine("[Negative Test Log] Lockout verification passed seamlessly!");
        }
    }
}
