using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class PlayService
    {
        private readonly AppDbContext _db;
        public PlayService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<WordOfTheDayStatsDto>> GetWordOfTheDayStats(DateTime? date = null, int days = 10, Guid? playerId = null)
        {
            if (days < 1 || days > 100) days = 10;
            var start = date ?? DateTime.UtcNow.AddHours(-12).Date;
            var end = start + TimeSpan.FromDays(days * -1);

            var result = await _db.DateWords
                .Include(d => d.Plays)
                .Where(d => d.Date <= start && d.Date > end)
                .OrderByDescending(d => d.Date)
                .Select(d => new WordOfTheDayStatsDto
                {
                    Date = d.Date,
                    AvgTime = d.Plays.Any() ? d.Plays.Average(a => a.Attempts) : -1,
                    NumberOfPlays = d.Plays.Count(),
                    HasUserPlayed = playerId.HasValue && d.Plays.Any(d => d.PlayerId == playerId.Value)
                })
                .ToListAsync();
            return result;
        }
    }
}