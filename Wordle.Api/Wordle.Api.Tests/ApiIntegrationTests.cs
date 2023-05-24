using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Wordle.Api.Tests;

[TestClass]
public class ApiIntegrationTests
{
    private static WebApplicationFactory<Program> s_factory = null!;

    [ClassInitialize]
    public static void ClassInit(TestContext testContext)
    {
        s_factory = new WebApplicationFactory<Program>();
    }

    [TestMethod]
    public async Task WordShouldReturnSuccessResponse()
    {
        var client = s_factory.CreateClient();
        var response = await client.GetAsync("word");

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual("text/plain; charset=utf-8",
                        response.Content.Headers.ContentType?.ToString());

        var json = await response.Content.ReadAsStringAsync();
        Assert.IsTrue(json.Length == 5);
    }

    [TestMethod]
    public async Task TopPlayersShouldReturnJson()
    {
        var client = s_factory.CreateClient();
        var response = await client.GetAsync("Player/TopPlayers");

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual("application/json; charset=utf-8",
                        response.Content.Headers.ContentType?.ToString());

        var json = await response.Content.ReadAsStringAsync();
        Assert.IsTrue(json.Contains("Susan"));
    }

    [TestMethod]
    public async Task WordOfTheDay()
    {
        var client = s_factory.CreateClient();
        var response = await client.GetAsync("Word/WordOfTheDay?offsetinhours=-8");

        var json = await response.Content.ReadAsStringAsync();
        Assert.IsTrue(json.Contains("word"));
        Assert.IsTrue(json.Contains("date"));
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        s_factory.Dispose();
    }
}
