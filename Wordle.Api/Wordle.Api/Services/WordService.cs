using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class WordService
    {
        private readonly AppDbContext _db;
        private static readonly object _WordOfTheDayLock = new object();

        public WordService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Word> GetRandomWord()
        {
            var count = await _db.Words.CountAsync(word => word.IsCommon);
            var index = new Random().Next(count);
            var word = await _db.Words
                .Where(word => word.IsCommon)
                .Skip(index)
                .FirstAsync();
            return word;
        }

        public async Task<IEnumerable<Word>> GetSeveralWords(int? count)
        {
            count ??= 10;
            var totalCount = await _db.Words.CountAsync(word => word.IsCommon);
            totalCount -= count.Value;
            int index = new Random().Next(totalCount);
            var words = await _db.Words
                .Where(word => word.IsCommon)
                .Skip(index)
                .Take(count.Value)
                .OrderByDescending(w => w.Text)
                .ToListAsync();
            return words;
        }

        public async Task<Word> AddWord(string? newWord, bool isCommon)
        {
            if (newWord is null || newWord.Length != 5)
            {
                throw new ArgumentException("Word must be 5 characters long");
            }
            var word = await _db.Words.FirstOrDefaultAsync(w => w.Text == newWord);
            if (word != null)
            {
                word.IsCommon = isCommon;
            }
            else
            {
                word = new()
                {
                    Text = newWord,
                    IsCommon = isCommon
                };
                _db.Words.Add(word);
            }
            await _db.SaveChangesAsync();
            return word;
        }
        public async Task<List<WordOfTheDayStatsDto>> GetWordOfTheDayStatsAsync
        (DateTime? date = null, int daysBack = 10, Guid? playerId = null)
        {
            if (daysBack < 1 || daysBack > 100) daysBack = 10;
            // Make sure we get the most recent day in the farthest timezone
            var startDate = date.HasValue ? date.Value : DateTime.UtcNow.AddHours(-12).Date;
            var endDate = startDate + TimeSpan.FromDays(daysBack * -1);

            // Get the data using the child collection of PlayerGames
            var result = await _db.DateWords
                .Include(f => f.PlayerGames)
                .Where(f => f.Date <= startDate && f.Date > endDate)
                .OrderByDescending(f => f.Date)
                .Select(f => new WordOfTheDayStatsDto
                {
                    Date = f.Date,
                    AverageDurationInSeconds = f.PlayerGames.Any() ? f.PlayerGames.Average(a => a.DurationInSeconds) : -1,
                    AverageAttempts = f.PlayerGames.Any() ? f.PlayerGames.Average(a => a.Attempts) : -1,
                    NumberOfPlays = f.PlayerGames.Count(),
                    HasUserPlayed = playerId.HasValue ? f.PlayerGames.Any(f => f.PlayerId == playerId.Value) : false
                })
                .ToListAsync();

            // If we don't have enough entries, then we need to add the days.
            if (result.Count != daysBack)
            {
                // We need to add the extra days
                for (int i = 0; i > (daysBack + 1) * -1; i--)
                {
                    // Use the timezone that is the worst possible one
                    await this.GetWordOfTheDay(TimeSpan.FromHours(12), startDate.AddDays(i));
                }
                // Go get the data again, hopefull this all works and we don't end up in a loop
                result = await GetWordOfTheDayStatsAsync(date, daysBack);
            }
            return result;
        }

        public async Task<string> GetWordOfTheDay(TimeSpan offset, DateTime? date = null)
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

            if (todaysWord != null)
            {
                return todaysWord.Word.Text;
            } else
            {
                lock (_WordOfTheDayLock)
                {
                    var todaysLatestWord = _db.DateWords
                        .Include(f => f.Word)
                        .FirstOrDefault(f => f.Date == localDate);

                    if (todaysLatestWord != null)
                    {
                        return todaysLatestWord.Word.Text;
                    }
                    var word = GetRandomWord().Result;

                    var dateWord = new DateWord
                    {
                        Date = localDate,
                        Word = word
                    };
                    _db.DateWords.Add(dateWord);
                    try
                    {
                        _db.SaveChanges();
                    }
                    catch(SqlException e) // this is probably not the right error to catch
                    {
                        if (e.Message.Contains("duplicate"))
                        {
                            return _db.DateWords
                                .Include(f => f.Word)
                                .First(f => f.Date == localDate)
                                .Word.Text;
                        }
                    }
                    return word.Text;
                }
            }
        }
    }
}