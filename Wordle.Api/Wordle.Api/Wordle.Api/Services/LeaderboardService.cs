using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class LeaderboardService
    {
        private readonly AppDbContext _db;
        public LeaderboardService(AppDbContext db) 
        {
            _db = db;
        }
        public async Task<string[]> GetTopScores() 
        {
            var players = await _db.Players
                .OrderBy(player => player.AverageAttempts)
                .ThenBy(player => player.GameCount)
                .Take(10)
                .ToArrayAsync();
            string[] scores = new string[players.Length];
            int count = 0;
            foreach (var player in players) 
            {
                scores[count] = $"{player.Name},{player.AverageAttempts},{player.GameCount}";
                count++;
            }
            return scores;
        }

        public async Task<Player> UpdatePlayer(string name, int attempts) 
        {
            Player? player = await _db.Players
                .FirstOrDefaultAsync(player => player.Name == name);

            if (player != null)
            {
                player.AverageAttempts = ((player.AverageAttempts * player.GameCount) + attempts) / (double)(player.GameCount + 1);
                player.GameCount++;
            }
            else 
            {
                player = new()
                {
                    Name = name,
                    AverageAttempts = attempts,
                    GameCount = 1
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<string[]> GetLastTenDays(string name)
        {
            var days = await _db.DateWords
                .OrderByDescending(d => d.DateWordId)
                .Take(10)
                .ToArrayAsync();
            var completions = await _db.DailyCompletions
                .Where(c => c.PlayerName == name)
                .Select(c => c.DateWordId)
                .ToArrayAsync();
            string[] dayStr = new string[days.Length];
            int count = 0;
            foreach (var day in days) 
            {
                dayStr[count] = $"{day.Date.ToString().Split(' ')[0]},{day.AverageAttempts},{day.Plays},{day.DateWordId},{day.AverageSeconds},{completions.Contains(day.DateWordId)}";
                count++;
            }
            return dayStr;
        }

        public async Task<DateWord?> UpdateDateWord(string word, int attempts, int seconds)
        {
            DateWord? dateWord = await _db.DateWords
                .FirstOrDefaultAsync(d => d.Word.Text == word);
            if (dateWord != null) {
                dateWord.AverageAttempts = ((dateWord.AverageAttempts * dateWord.Plays) + attempts) / (dateWord.Plays + 1);
                dateWord.AverageSeconds = ((dateWord.AverageSeconds * dateWord.Plays) + seconds) / (dateWord.Plays + 1);
                dateWord.Plays++;
            }

            await _db.SaveChangesAsync();
            return dateWord;
        }
        public async Task<DailyCompletions> AddDailyCompletion(string name, string word) 
        {
            DateWord? dateWord = _db.DateWords.Where(w => w.Word.Text == word).FirstOrDefault();
            DailyCompletions daily = new();
            if (dateWord != null)
            {
                daily = new()
                {
                    DateWordId = dateWord.DateWordId,
                    PlayerName = name,
                };
                _db.DailyCompletions.Add(daily);
            }
            await _db.SaveChangesAsync();
            return daily;

        }
    }
}