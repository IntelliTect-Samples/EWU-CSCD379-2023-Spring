using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class ApiIntegrationTests
    {
        private static WebApplicationFactory<Program> _factory = null!;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _factory = new WebApplicationFactory<Program>();
        }


        [TestMethod]
        public async Task WordShouldReturnSuccessResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("word");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("text/plain; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var json = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(json.Length == 5);
        }

        [TestMethod]
        public async Task TopPlayersShouldReturnJson()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("Player/TopPlayers");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var json = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(json.Contains("Susan"));
        }

        [TestMethod]
        public async Task WordOfTheDay()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("word/wordoftheday?offsetinhours=-8");

            var json = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(json.Contains("word"));
            Assert.IsTrue(json.Contains("date"));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }

    }
}
