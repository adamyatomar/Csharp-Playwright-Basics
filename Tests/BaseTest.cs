using System.Threading.Tasks;
using System;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Framework.Utils;
using System.Runtime.CompilerServices;
using NUnit.Framework.Internal;

namespace Framework.Tests
{
    [TestFixture]
    public class BaseTest : PageTest
    {
        protected IBrowserContext _browsercontext = null!;
        protected IPage _page = null!;
        
        [SetUp]

        public async Task MasterBaseSetup()
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

        [TearDown]
     
          public async Task MasterBaseTeardown()
        {
            var customtime = new FrameworkUtils();

            string time = customtime.GetCustomTimestamp();

            await _browsercontext.Tracing.StopAsync(new TracingStopOptions
            {
                Path = $"Traces/trace_{TestContext.CurrentContext.Test.Name}_{time}.zip"
            });

            await _browsercontext.CloseAsync();

        }

    }
}