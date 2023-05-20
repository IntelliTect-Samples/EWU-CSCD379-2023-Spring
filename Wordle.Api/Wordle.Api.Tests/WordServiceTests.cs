using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
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

            var word = await service.GetRandomWordAsync();

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
            
            var word = await service.GetWordOfTheDayAsync(TimeSpan.FromHours(-8), date);
            
            var word2 = await service.GetWordOfTheDayAsync(TimeSpan.FromHours(-8), date);

            Assert.AreEqual(word, word2);
        }

        [TestMethod]
        public async Task WordOfTheDayStats()
        {
            using var context = new AppDbContext(Options);
            Seeder.Seed(context);
            var playerService = new PlayerService(context);
            var wordService = new WordService(context);

            var PlayerId1 = (await playerService.CreateAsync("Tester1")).PlayerId;
            var PlayerId2 = (await playerService.CreateAsync("Tester2")).PlayerId;
            var wordOfTheDay1 = await wordService.GetWordOfTheDayAsync(TimeSpan.FromHours(-7), DateTime.UtcNow);
            var wordOfTheDay2 = await wordService.GetWordOfTheDayAsync(TimeSpan.FromHours(-7), DateTime.UtcNow.AddDays(-1));
            var wordOfTheDay3 = await wordService.GetWordOfTheDayAsync(TimeSpan.FromHours(-7), DateTime.UtcNow.AddDays(-2));


            GameResultDto dto = new()
            {
                PlayerId = PlayerId1,
                WordPlayed = wordOfTheDay1.Word.Text,
                WasGameWon = true,
                Attempts = 3,
                DurationInSeconds = 10,
                WordOfTheDayDate = wordOfTheDay1.Date
            };
            var playerGame = await playerService.AddGameResultAsync(dto);
            Assert.IsNotNull(playerGame.DateWord);

            dto = new()
            {
                PlayerId = PlayerId2,
                WordPlayed = wordOfTheDay1.Word.Text,
                WasGameWon = true,
                Attempts = 1,
                DurationInSeconds = 4,
                WordOfTheDayDate = wordOfTheDay1.Date
            };
            await playerService.AddGameResultAsync(dto);

            dto = new()
            {
                PlayerId = PlayerId1,
                WordPlayed = wordOfTheDay2.Word.Text,
                WasGameWon = true,
                Attempts = 3,
                DurationInSeconds = 10,
                WordOfTheDayDate = wordOfTheDay2.Date
            };
            await playerService.AddGameResultAsync(dto);
            dto = new()
            {
                PlayerId = PlayerId1,
                WordPlayed = wordOfTheDay3.Word.Text,
                WasGameWon = true,
                Attempts = 3,
                DurationInSeconds = 10,
                WordOfTheDayDate = wordOfTheDay3.Date
            };
            await playerService.AddGameResultAsync(dto);



            // Check the stats
            var stats = await wordService.GetWordOfTheDayStatsAsync();
            Assert.AreEqual(10, stats.Count());
            Assert.AreEqual(2, stats[0].NumberOfPlays);
            Assert.AreEqual(1, stats[1].NumberOfPlays);
            Assert.AreEqual(1, stats[2].NumberOfPlays);
            Assert.AreEqual(0, stats[3].NumberOfPlays);
            Assert.AreEqual(7, stats[0].AverageDurationInSeconds);
            Assert.AreEqual(10, stats[1].AverageDurationInSeconds);
            Assert.AreEqual(10, stats[2].AverageDurationInSeconds);
            Assert.AreEqual(-1, stats[3].AverageDurationInSeconds);
            Assert.AreEqual(2, stats[0].AverageAttempts);
            Assert.AreEqual(3, stats[1].AverageAttempts);
            Assert.AreEqual(3, stats[2].AverageAttempts);
            Assert.AreEqual(-1, stats[3].AverageAttempts);

        }
    }
}
