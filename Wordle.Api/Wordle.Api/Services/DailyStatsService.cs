using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class DailyStatsService
    {
        private readonly AppDbContext _db;

        public DailyStatsService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<DateWordStats?> AddDailyGameResultAsync(DateWordDto dto)
        {
            var added = await _db.DailyStats.FindAsync(dto.WordPlayed);
            if (added is not null)
            {
                if (dto.WasGameWon)
                {
                    added.numberOfPlays++;
                    added.totalTime += dto.DurationInSeconds;
                    added.averageTime = added.totalTime / added.numberOfPlays;
                    added.averageScore = 1;

                    await _db.SaveChangesAsync();
                }
                return added;
            }
            throw new ArgumentException("game lost");
        }

        public async Task<IEnumerable<DateWordStats>> GetLastTenWords(int count = 10)
        {
            return await _db.DailyStats
                .OrderBy(f => f.DateWordStatsId)
                .Take(count)
                .ToListAsync();
        }
    }
}
