using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayService
    {
        private readonly AppDbContext _db;

        private record PlayerStatistics(string UserName, int GameCount, double AvgAttempts, double AvgSeconds); 

        public PlayService(AppDbContext db)
        {
            _db = db;
        }




        public async Task<Player> AddPlayer(string? newPlayerName, int attempts, double secondsToComplete)
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
                player.AverageSecondsPerGame = secondsToComplete;

            }
            else
            {
                player = new()
                {
                    Name = newPlayerName,
                    GameCount = 1,
                    AverageAttempts = attempts,
                    AverageSecondsPerGame = secondsToComplete
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }


        public async Task<Player> InsertScore(string? newPlayerName, int numAttempts, double secondsToComplete)
        {

            if (newPlayerName is null)
            {
                newPlayerName = "Guest";
            }
            // First we check if the player is in the game
            bool playerExists = _db.Players.AnyAsync((player) => player.Name.Equals(newPlayerName)).Result;
            if (!playerExists) {
                return await AddPlayer(newPlayerName, numAttempts, secondsToComplete);

            }
      
            // Retrieve the player from the database
            Player player = await _db.Players.FirstAsync(w => w.Name == newPlayerName);

            // Access its avgAttemtps and numGames
            double avgAttempts = player.AverageAttempts;
            double avgSeconds = player.AverageSecondsPerGame; 
            int numGames = player.GameCount;
            
           

            // Update its avgAttempts and numGames
            double totalScore = avgAttempts * numGames;
            double totalSeconds = avgSeconds * numGames;
            totalSeconds += secondsToComplete; 
            totalScore += numAttempts;
            numGames++;



            player.AverageAttempts = totalScore / numGames;
            player.AverageSecondsPerGame = totalSeconds / numGames;
            player.GameCount = numGames;
            await _db.SaveChangesAsync();

            return player;

         
        }

        public async Task<string> GetTopTenPlayers()
        {
            // First, create an array of records 
            PlayerStatistics[] playerStatistics = new PlayerStatistics[_db.Users.Count()];

            // Second, initialize that array of records
            foreach (User user in _db.Users)
            {
                // 0) Get the players id based on their name 
                int id = user.UserId;
                // 1) Get each player name 
                string userName = user.Name;
                // 2) Compute games played 
                int gameCount = await _db.Plays.Where(play => play.UserId == id).CountAsync();
                // 3) Compute average attempts
                double avgAttempts = await _db.Plays.Where(play => play.UserId == id).AverageAsync(play => play.Attempts);
                // 4) Compute average seconds
                double avgSeconds = await _db.Plays.Where(play => play.UserId == id).AverageAsync(play => play.Seconds);

                playerStatistics.Append(new PlayerStatistics(userName, gameCount, avgAttempts, avgSeconds)); 


            }
            return JsonConvert.SerializeObject 
            (playerStatistics.OrderBy((stats) => stats.AvgAttempts)
                .OrderByDescending((stats) => stats.GameCount).Take(10).ToList()); 

        }

    }
}

