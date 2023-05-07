using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        private readonly AppDbContext _db;

        public PlayerService(AppDbContext db)
        {
            _db = db;
        }

        public Player[] GetTop10()
        {
            return _db.Players.OrderBy(player => player.AverageAttempts).Take(10).ToArray();
        }



        public async Task<Player> AddPlayer(string? newPlayerName, int attempts)
        {
            if (newPlayerName is null)
            {
                newPlayerName = "Guest";
            }
            var player = await _db.Players.FirstOrDefaultAsync(w => w.Name == newPlayerName);
            if (player != null)
            {
                player.GameCount = 1;
                player.AverageAttempts = attempts; 
            }
            else
            {
                player = new()
                {
                    Name = newPlayerName,
                    GameCount = 1,
                    AverageAttempts = attempts
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }


        public async Task<Player> InsertScore(string? newPlayerName, int numAttempts)
        {
            if (newPlayerName is null)
            {
                newPlayerName = "Guest";
            }
            // First we check if the player is in the game
            bool playerExists = _db.Players.AnyAsync((player) => player.Name.Equals(newPlayerName)).Result;
            if (!playerExists) {
                return await AddPlayer(newPlayerName, numAttempts);

            }
      
            // Retrieve the player from the database
            Player player = await _db.Players.FirstAsync(w => w.Name == newPlayerName);

            // Access its avgAttemtps and numGames
            double avgAttempts = player.AverageAttempts;
            int numGames = player.GameCount;

            // Update its avgAttempts and numGames
            double totalScore = avgAttempts * numGames;
            totalScore += numAttempts;
            numGames++;

            player.AverageAttempts = totalScore / numGames;
            player.GameCount = numGames;
            await _db.SaveChangesAsync();

            return player;

         
        }

        public async Task<string> GetTopTenPlayers()
        {
            return JsonConvert.SerializeObject 
            (await _db.Players.OrderBy((player) => player.AverageAttempts)
                .OrderByDescending((player) => player.GameCount).Take(10).ToListAsync()); 

        }

    }
}

