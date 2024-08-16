using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Playwright_Automation.POM;
using System.Runtime.InteropServices;


namespace Playwright_Automation.UITests
{
    [TestFixture("chromium")]
    [TestFixture("firefox")]
    [TestFixture("edge")]
    [Parallelizable(ParallelScope.All)]
    public class UITests
    {

        private readonly string _browserType;
        private IPlaywright PlaywrightInstance { get; set; }
        protected IBrowser Browser { get; private set; }
        protected IPage Page { get; private set; }
        protected IBrowserType BrowserTypeInstance { get; private set; }

        public UITests(string browserType)
        {
            _browserType = browserType;
        }


        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            PlaywrightInstance = await Playwright.CreateAsync();
            BrowserTypeInstance = _browserType switch
            {
                "chromium" => PlaywrightInstance.Chromium,
                "firefox" => PlaywrightInstance.Firefox,
                "edge" => PlaywrightInstance.Chromium, // Edge is part of Chromium
                _ => throw new ArgumentException($"Unknown browser type: {_browserType}")
            };
        }


        [SetUp]
        public async Task Setup()
        {
            var headless = bool.Parse(TestContext.Parameters.Get("Headless", "false"));

            var browserOptions = new BrowserTypeLaunchOptions
            {
                Headless = headless
            };


            if (_browserType == "edge")
            {
                browserOptions.Channel = "msedge"; // Edge channel
            }

            Browser = await BrowserTypeInstance.LaunchAsync(browserOptions);
            var context = await Browser.NewContextAsync();
            Page = await context.NewPageAsync();
        }


        

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            PlaywrightInstance?.Dispose();
        }


        [Test]
        public async Task RegisterUser_With_DeleteAccount()
        {
            //Home Page
            HomePage homePage = new HomePage(Page);
            await homePage.GotoUrl("http://automationexercise.com");
            await homePage.GotoHomePage();
            await homePage.ValidateHomePage();
            await homePage.GotoLoginSignupPage();

            //LoginSignUp Page
            Login_SignupPage loginSignUpPage = new Login_SignupPage(Page);
            await loginSignUpPage.SignUp("Zeeshan Essani", "zeeshanessani@gmail.com");
            await loginSignUpPage.Validate_Successful_SignUp();

            //RegisterationPage
            RegisterationPage registerationPage = new RegisterationPage(Page);
            await registerationPage.Register(

                "tpstps_123",
                "18",
                "5",
                "1992",
                "Zeeshan",
                "Essani",
                "Contour Software Pvt. Ltd",
                "Flat#5 Building#4 Trust Gulshan e Noor Society Scheme 33",
                "Sindh",
                "Karachi",
                "75330",
                "03471233262"

                );
            await registerationPage.SuccessFullRegistration_Validation();


            await Page.GetByRole(AriaRole.Link, new() { Name = "Continue" }).ClickAsync();
            //await Expect(Page.GetByText("Logged in as Zeeshan Essani")).ToBeVisibleAsync(new() { Timeout = 10_000 });


            await Page.GetByRole(AriaRole.Link, new() { Name = " Delete Account" }).ClickAsync();
            // await Expect(Page.GetByText("Account Deleted!")).ToBeVisibleAsync(new() { Timeout = 10_000 });

        }


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


        [Test]
        public async Task LoginUser_with_InvalidCredentials()
        {
            //Home Page
            HomePage homePage = new HomePage(Page);
            await homePage.GotoUrl("http://automationexercise.com");
            await homePage.GotoLoginSignupPage();

            //LoginSignUp Page
            Login_SignupPage loginSignUpPage = new Login_SignupPage(Page);
            await loginSignUpPage.Login("zeeshanessani@umail.com", "tptstps_123");
            await loginSignUpPage.Validate_UnSuccessfull_Login();
        }



    }
}
