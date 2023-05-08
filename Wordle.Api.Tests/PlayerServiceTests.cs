using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        public void GetLeaderboard()
        {
            using var context = new AppDbContext(Options);
            var service = new LeaderboardService(context);
            Player.SeedPlayers(context);

            var leaderboard = service.GetLeaderboard();

            Assert.IsNotNull(leaderboard);

            Assert.IsTrue(leaderboard is List<Player>);

        }

        [TestMethod]
        public async Task AddPlayer()
        {
            using var context = new AppDbContext(Options);
            var service = new LeaderboardService(context);
            Player.SeedPlayers(context);

            await service.AddPlayer("TestName", 1, 1);

            var player = context.Players.First(p => p.Name == "TestName");

            Assert.IsInstanceOfType(player, typeof(Player));

        }
    }
}
