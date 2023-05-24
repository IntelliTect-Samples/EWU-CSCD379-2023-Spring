using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class DateWordService
    {
        private readonly AppDbContext _db;

        public DateWordService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<DateWord?> AddDailyGameResultAsync(GameResultDto dto)
        {
            var player = await _db.Players.FindAsync(dto.PlayerId);
            if (player is not null)
            {
                var fetchedEntry = await _db.DateWords.FindAsync(dto.WordPlayed);
                if (fetchedEntry is not null && !fetchedEntry.PreviousPlayers.Contains(player))
                {
                    fetchedEntry.TotalSeconds += dto.DurationInSeconds;
                    fetchedEntry.TotalAttempts += dto.Attempts;
                    fetchedEntry.PreviousPlayers.Add(player);
                    fetchedEntry.TotalGames += 1;
                    await _db.SaveChangesAsync();
                
                    return fetchedEntry;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<DateWord>> GetLastTenWords(int count = 10)
        {
            return await _db.DateWords
                .OrderBy(f => f.Date)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IList<Player>?> ReturnListOfPlayersForWordOfTheDay(TimeSpan offset, DateTime? date = null)
        {
            var temp = DateTime.UtcNow;
            if (date is null)
            {
                date = temp;
            }

            var localDateTime = new DateTimeOffset(date.Value.Ticks, offset);
            var tempDateTime = new DateTimeOffset(temp.Ticks, offset);
            var localDate = localDateTime.Date;
            var tempDate = tempDateTime.Date;
            if (localDate > tempDate)
            {
                localDate = tempDate;
            }
            var todaysWord = await _db.DateWords
                .Include(f => f.Word)
                .FirstOrDefaultAsync(f => f.Date == localDate);
            if (todaysWord is null)
            {
                return null;
            }
            return todaysWord.PreviousPlayers;
        }
    }
}
