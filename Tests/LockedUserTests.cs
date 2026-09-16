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
        private IBrowserContext _browsercontext = null!;
        private IPage _page = null!;

        [SetUp]

        public async Task LockedUserSetup()
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
            await  _page.GotoAsync("https://saucedemo.com");

            var finalLogin = new LoginPage( _page);
            await finalLogin.FullLoginCredentials(user, pass);

            
           
          ILocator errorbox =  _page.Locator("[data-test='error']");

            string errorText = await errorbox.TextContentAsync() ?? string.Empty;
            
            Assert.That(errorText, Does.Contain("locked out"), 
                "CRITICAL FAILURE: Locked out error message was missing from the UI panel!");
                
            Console.WriteLine("[Negative Test Log] Lockout verification passed seamlessly!");
        }

        [TearDown]

        public async Task LockedUserTeardown()
        {
            var customtime = new FrameworkUtils();

            string time = customtime.GetCustomTimestamp();

            await _browsercontext.Tracing.StopAsync(new TracingStopOptions
            {

                Path = $"Traces/trace_LockedUser_{time}.zip" 
                
            });

            await _browsercontext.CloseAsync();

        }
    }
}
