using Microsoft.Playwright;


namespace Playwright_Automation.APITests
{
    public class APIUnitTest
    {
        [Test]
        public async Task Test_GetAllProductsList_01()
        {

            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {

                BaseURL = "https://automationexercise.com/",
                IgnoreHTTPSErrors = true


            });

            var response = await requestContext.GetAsync(url: "/api/productsList");
            Assert.That(200, Is.EqualTo(response.Status), "Expected status code 200, but got " + response.Status);
            var responseBody = await response.TextAsync();
            Console.WriteLine(responseBody);
            Assert.IsNotEmpty(responseBody, "Response body is empty");

        }

        [Test]
        public async Task Test_PostToAllProductsList_02()
        {

            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {

                BaseURL = "https://automationexercise.com/",
                IgnoreHTTPSErrors = true


            });

            var response = await requestContext.PostAsync(url: "/api/productsList");
            Assert.That(200, Is.EqualTo(response.Status), "Expected status code 200, but got " + response.Status);
            var responseBody = await response.TextAsync();
            Console.WriteLine(responseBody);
            Assert.IsNotEmpty(responseBody, "Response body is empty");

        }

        [Test]
        public async Task Test_GetAllBrandsList_03()
        {

            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {

                BaseURL = "https://automationexercise.com/",
                IgnoreHTTPSErrors = true


            });

            var response = await requestContext.GetAsync(url: "/api/brandsList");
            Assert.That(200, Is.EqualTo(response.Status), "Expected status code 200, but got " + response.Status);
            var responseBody = await response.TextAsync();
            Console.WriteLine(responseBody);
            Assert.IsNotEmpty(responseBody, "Response body is empty");

        }

        [Test]
        public async Task Test_PutToAllBrandsList_04()
        {

            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {

                BaseURL = "https://automationexercise.com/",
                IgnoreHTTPSErrors = true


            });

            var response = await requestContext.PutAsync(url: "/api/brandsList");
            Assert.That(200, Is.EqualTo(response.Status), "Expected status code 200, but got " + response.Status);
            var responseBody = await response.TextAsync();
            Console.WriteLine(responseBody);
            Assert.IsNotEmpty(responseBody, "Response body is empty");

        }

        [Test]
        public async Task Test_PostToSearchProducts_05()
        {

            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {

                BaseURL = "https://automationexercise.com/",
                IgnoreHTTPSErrors = true


            });

            var response = await requestContext.PutAsync(url: "/api/brandsList");
            Assert.That(200, Is.EqualTo(response.Status), "Expected status code 200, but got " + response.Status);
            var responseBody = await response.TextAsync();
            Console.WriteLine(responseBody);
            Assert.IsNotEmpty(responseBody, "Response body is empty");

        }





    }
}
