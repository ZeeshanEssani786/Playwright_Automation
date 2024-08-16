using Microsoft.Playwright;
using Playwright_Automation.POM;


namespace Playwright_Automation.Utilities
{

    [TestFixture("chromium", "latest", "Windows 10")]
    [TestFixture("firefox", "latest", "Windows 10")]
    [TestFixture("msedge", "latest", "Windows 10")]
    [Parallelizable(ParallelScope.All)]
    public class SauceLabsExecutions
    {

        private readonly string _browserType;
        private readonly string _browserVersion;
        private readonly string _platform;
        private IPlaywright PlaywrightInstance { get; set; }
        private IBrowser Browser { get; set; }
        private IPage Page { get; set; }

        public SauceLabsExecutions(string browserType, string browserVersion, string platform)
        {
            _browserType = browserType;
            _browserVersion = browserVersion;
            _platform = platform;
        }

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            PlaywrightInstance = await Playwright.CreateAsync();
        }


        [SetUp]
        public async Task Setup()
        {
            var headless = bool.Parse(TestContext.Parameters.Get("Headless", "false"));

            var sauceUsername = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
            var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");

            if (string.IsNullOrEmpty(sauceUsername) || string.IsNullOrEmpty(sauceAccessKey))
            {
                throw new InvalidOperationException("Sauce Labs credentials are not set in the environment variables.");
            }

            var sauceOptions = new Dictionary<string, object>
            {
                ["name"] = TestContext.CurrentContext.Test.Name,
                ["build"] = $"playwright-build-3TASX",
                ["tunnelIdentifier"] = "oauth-zeeshan.bahadur-96439_tunnel_name"
            };

            var capabilities = new Dictionary<string, object>
            {
                ["browserName"] = _browserType,
                ["browserVersion"] = _browserVersion,
                ["platformName"] = _platform,
                ["sauce:options"] = sauceOptions
            };

            var playwright = await Playwright.CreateAsync();

            /*var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = headless,
                Timeout = 30000, // Customize your timeout
                SlowMo = 500, // Add slow motion if needed
                Channel = _browserType == "edge" ? "msedge" : null, // Use msedge for edge browser
            };*/

            var wsEndpoint = $"wss://{sauceUsername}:{sauceAccessKey}@ondemand.saucelabs.com:443";


            Browser = await PlaywrightInstance[_browserType].ConnectAsync(wsEndpoint, new BrowserTypeConnectOptions
            {           
                Timeout = 30000, // Customize your timeout
                SlowMo = 500 // Add slow motion if needed
               
            });

            
            


            var context = await Browser.NewContextAsync();
            Page = await context.NewPageAsync();
            await Page.GotoAsync("http://automationexercise.com");
        }




        /*[OneTimeTearDown]
        public async Task OneTimeTeardown()
        {
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }
            PlaywrightInstance?.Dispose();
        }*/





        [Test]
        public async Task LoginUser_with_ValidCredentials()
        {
            //Home Page
            HomePage homePage = new HomePage(Page);
            await homePage.GotoUrl("http://automationexercise.com");
            await homePage.GotoLoginSignupPage();

            //LoginSignUp Page
            Login_SignupPage loginSignUpPage = new Login_SignupPage(Page);
            await loginSignUpPage.Login("zeeshan.bahadur@contour-software.com", "idsids_123");
            await loginSignUpPage.Validate_Successfull_Login();

        }






    }
}
