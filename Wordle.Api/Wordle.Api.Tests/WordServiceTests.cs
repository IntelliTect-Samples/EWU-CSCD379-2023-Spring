﻿using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
[TestClass]
public class WordServiceTests : DatabaseTestBase
{
    [TestMethod]
    public async Task GetWord()
    {
        using var context = new AppDbContext(Options);
        var service = new WordService(context);
        Seeder.Seed(context);

        var word = await service.GetRandomWord();

        Assert.IsNotNull(word);
        Assert.AreEqual(5, word.Text.Length);
    }

    [TestMethod]
    public async Task GetWordOfTheDay()
    {
        using var context = new AppDbContext(Options);
        var service = new WordService(context);
        Seeder.Seed(context);

        var date = DateTime.UtcNow;

        var word = await service.GetWordOfTheDay(TimeSpan.FromHours(-8), date);

        var word2 = await service.GetWordOfTheDay(TimeSpan.FromHours(-8), date);

        Assert.AreEqual(word, word2);
    }
}
}
