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

        public async Task<DateWord?> AddDailyGameResultAsync(DateWordDto dto)
        {
            var added = await _db.DateWords.FindAsync(dto.DateWordId);
            if (added is not null)
            {
                added.TotalSeconds += dto.TotalSeconds;
                added.TotalAttempts += dto.TotalAttempts;
                added.TotalGames += dto.TotalGames;
                await _db.SaveChangesAsync();
                
                return added;
            }
            else
            {
                DateWord dateWord = new()
                {
                    DateWordId = dto.DateWordId,
                    Date = dto.Date,
                    WordId = dto.WordId,
                    Word = dto.Word,
                    TotalAttempts = dto.TotalAttempts,
                    TotalSeconds = dto.TotalSeconds,
                    TotalGames = dto.TotalGames,
                };
                return dateWord;
            }
        }

        public async Task<IEnumerable<DateWord>> GetLastTenWords(int count = 10)
        {
            return await _db.DateWords
                .OrderBy(f => f.Date)
                .Take(count)
                .ToListAsync();
        }
    }
}
