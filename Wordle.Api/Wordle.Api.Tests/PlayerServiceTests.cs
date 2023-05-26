using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Tests;
[TestClass]
public class PlayerServiceTests : DatabaseTestBase
{
    [TestMethod]
    public async Task GetTopPlayers()
    {
        using var context = new AppDbContext(Options);
        Seeder.Seed(context);
        var service = new PlayerService(context);

        var players = await service.GetTopPlayersAsync();

        Assert.IsNotNull(players);
        Assert.AreEqual(4, players.Count());
        Assert.AreEqual(2.7, players.First().AverageAttempts);
    }

    [TestMethod]
    public async Task CreateAndGetPlayer()
    {
        using var context = new AppDbContext(Options);
        Seeder.Seed(context);
        var service = new PlayerService(context);

        var guid = (await service.CreateAsync("Tester")).PlayerId;
        var player = await service.GetAsync(guid);

        Assert.IsNotNull(player);
        Assert.AreEqual(guid, player.PlayerId);
    }


    [TestMethod]
    public async Task AddGameResult()
    {
        using var context = new AppDbContext(Options);
        Seeder.Seed(context);
        var playerService = new PlayerService(context);
        var wordService = new WordService(context);

        var guid = (await playerService.CreateAsync("Tester")).PlayerId;
        var wordOfTheDay = await wordService.GetWordOfTheDayAsync(TimeSpan.FromHours(-7));


        GameResultDto dto = new()
        {
            PlayerId = guid,
            WordPlayed = wordOfTheDay.Word.Text,
            WasGameWon = true,
            Attempts = 3,
            DurationInSeconds = 10,
            WordOfTheDayDate = wordOfTheDay.Date
        };

        var playerGame = await playerService.AddGameResultAsync(dto);
        Assert.IsNotNull(playerGame.DateWord);

        // Check the stats
        var stats = await wordService.GetWordOfTheDayStatsAsync();
        Assert.AreEqual(10, stats.Count());
        Assert.AreEqual(1, stats.First().NumberOfPlays);
        Assert.AreEqual(10, stats.First().AverageDurationInSeconds);
        Assert.AreEqual(3, stats.First().AverageAttempts);

    }
}
