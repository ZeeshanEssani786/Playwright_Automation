using Microsoft.Playwright;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;


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


        [Test]
        public async Task Test_GetUsers()
        {

            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {

                BaseURL = "https://gorest.co.in",
                IgnoreHTTPSErrors = true


            });

            var response = await requestContext.GetAsync(url: "/public/v2/users");
            Console.WriteLine(response);

            Assert.That(200, Is.EqualTo(response.Status), "Expected status code 200, but got " + response.Status);
            var responseBody = await response.TextAsync();
            Console.WriteLine(responseBody);
            Assert.IsNotEmpty(responseBody, "Response body is empty");

        }


        [Test]
        public async Task Test_GetSpecificUser()
        {

            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {

                BaseURL = "https://gorest.co.in",
                IgnoreHTTPSErrors = true


            });

            var response = await requestContext.GetAsync(url: "/public/v2/users/7351978");
            Console.WriteLine(response);

            Assert.That(200, Is.EqualTo(response.Status), "Expected status code 200, but got " + response.Status);
            var responseBody = await response.TextAsync();
            Console.WriteLine(responseBody);
            Assert.IsNotEmpty(responseBody, "Response body is empty");

        }


        [Test]
        public async Task Test_CreateUser()
        {

            var playwright = await Playwright.CreateAsync();

            var headers = new Dictionary<string, string>
            {
            // We set this header per GitHub guidelines.
            { "Accept", "*/*" },
            // Add authorization token to all requests.
            // Assuming personal access token available in the environment.
            { "Authorization", "Bearer 61f447c12416fc6b9a63c3359b00fdb54c4e7ff9b3bea20fc25a9cd3f146d8f2" }

            };


            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {

                BaseURL = "https://gorest.co.in",
                IgnoreHTTPSErrors = true,
                ExtraHTTPHeaders = headers


            });

            var data = new Dictionary<string, string>
            {
            { "name", "Kali Waaali Zulfon" },
            { "email", "kaliWli_Zulfon@botsford.example" },
            { "gender", "female"},
            { "status",  "active"}
            };




            var response = await requestContext.PostAsync(url: "/public/v2/users", new() { DataObject = data });

            Console.WriteLine(response);

            Assert.That(201, Is.EqualTo(response.Status), "Expected status code 201, but got " + response.Status);
            var responseBody = await response.TextAsync();
            Console.WriteLine(responseBody);
            Assert.IsNotEmpty(responseBody, "Response body is empty");

        }


        [Test]
        public async Task Test_UpdateUser()
        {

            var playwright = await Playwright.CreateAsync();

            var headers = new Dictionary<string, string>
            {
            // We set this header per GitHub guidelines.
            { "Accept", "*/*" },
            // Add authorization token to all requests.
            // Assuming personal access token available in the environment.
            { "Authorization", "Bearer 61f447c12416fc6b9a63c3359b00fdb54c4e7ff9b3bea20fc25a9cd3f146d8f2" }

            };


            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {

                BaseURL = "https://gorest.co.in",
                IgnoreHTTPSErrors = true,
                ExtraHTTPHeaders = headers


            });

            var data = new Dictionary<string, string>
            {
            { "name", "Kali Waaali Zulfonnn" },

            };




            var response = await requestContext.PutAsync(url: "/public/v2/users/7351978", new() { DataObject = data });

            Console.WriteLine(response);

            Assert.That(200, Is.EqualTo(response.Status), "Expected status code 200, but got " + response.Status);
            var responseBody = await response.TextAsync();
            Console.WriteLine(responseBody);
            Assert.IsNotEmpty(responseBody, "Response body is empty");

        }


        [Test]
        public async Task Test_DeleteSpecificUser()
        {

            var playwright = await Playwright.CreateAsync();
            var headers = new Dictionary<string, string>
            {
            // We set this header per GitHub guidelines.
            { "Accept", "*/*" },
            // Add authorization token to all requests.
            // Assuming personal access token available in the environment.
            { "Authorization", "Bearer 61f447c12416fc6b9a63c3359b00fdb54c4e7ff9b3bea20fc25a9cd3f146d8f2" }

            };


            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
            {

                BaseURL = "https://gorest.co.in",
                IgnoreHTTPSErrors = true,
                ExtraHTTPHeaders = headers


            });

            var response = await requestContext.DeleteAsync(url: "/public/v2/users/7351970");
            Console.WriteLine(response);

            Assert.That(204, Is.EqualTo(response.Status), "Expected status code 204, but got " + response.Status);
            var responseBody = await response.TextAsync();
           

        }

    }
}
