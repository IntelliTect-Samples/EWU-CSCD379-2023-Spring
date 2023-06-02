using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
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

            var guid = (await service.CreateAsync("Grant")).PlayerId;
            var player = await service.GetAsync(guid);
                        
            Assert.IsNotNull(player);
            Assert.AreEqual(guid, player.PlayerId);
        }

    }
}
