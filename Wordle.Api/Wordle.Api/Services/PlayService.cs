using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

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
        public async Task<string> InsertPlay_AndIfPlayerDoesNotExist_InsertPlayer(PlayDto playDto) {

            string name = playDto.Name;
            if (name is null)
            {
                name = "Guest";
            }

            // If the player doesn't exist, add player to DB
            AppUser? newUser = await _db.Users.FirstOrDefaultAsync(user => user.Name == name);
            // If the player does not exist
            if (newUser == null)
            {

                newUser = new AppUser() { Name = name }; 
                _db.Users.Add(newUser);
            }
            await _db.SaveChangesAsync();

            // Attain the players id 
            int userId = (await _db.Users.Where(user => user.Name == name).FirstAsync()).UserId;
            int wordId = (await _db.Words.Where(word => word.Text == playDto.Word).FirstAsync()).WordId;

            // Add a play into the play database
            _db.Plays.Add(new Play()
            {
                User = Play.StringToUser(name, _db),
                Word = Play.StringToWord(playDto.Word, _db),
                Attempts = playDto.Attempts,
                Seconds = playDto.Seconds
            }); 
            await _db.SaveChangesAsync();
            return ""; 
       
        }


        public async Task<string> GetTopTenPlayers()
        {

            // First, create a list to store the player statistics
            List<PlayerStatistics> playerStatistics = new List<PlayerStatistics>();

            // Retrieve all users from the database
            List<AppUser> users = await _db.Users.ToListAsync();

            // Iterate over the users and retrieve their associated plays
            foreach (AppUser user in users)
            {
                int id = user.UserId;
                string userName = user.Name;

                // Retrieve the player's plays
                List<Play> plays = await _db.Plays.Where(play => play.UserId == id).ToListAsync();

                int gameCount = plays.Count;
                if (gameCount > 0)
                {
                    double avgAttempts = plays.Average(play => play.Attempts);
                    double avgSeconds = plays.Average(play => play.Seconds);

                    playerStatistics.Add(new PlayerStatistics(userName, gameCount, avgAttempts, avgSeconds));
                }
            }

            // Sort the player statistics and return the top 10 as a JSON string
            return JsonConvert.SerializeObject(
                playerStatistics
                    .OrderBy((stats) => stats.AvgAttempts)
                    .OrderByDescending((stats) => stats.GameCount)
                    .Take(10)
                    .ToList()
            );

        }     
    }
}

