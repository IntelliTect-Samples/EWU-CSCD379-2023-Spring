using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Identity;
using static Azure.Core.HttpHeader;

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

        public async Task<DateWord> GetWordOfTheDay(TimeSpan offset, DateTime? date = null)
        {
            if (date is null)
            {
                date = DateTime.UtcNow;
            }

            var localDateTime = new DateTimeOffset(date.Value.Ticks, offset);
            var localDate = localDateTime.Date;
            //var truelocalDate = localDate.AddDays(-1);
            var todaysWord = await _db.DateWords
                .Include(f => f.Word)
                .FirstOrDefaultAsync(f => f.Date == localDate);
                //.FirstOrDefaultAsync(f => f.Date == truelocalDate);

            if (todaysWord != null)
            {
                return todaysWord;
            }
            else
            {
                lock (_WordOfTheDayLock)
                {
                    var todaysLatestWord = _db.DateWords
                        .Include(f => f.Word)
                        .FirstOrDefault(f => f.Date == localDate);
                        //.FirstOrDefault(f => f.Date == truelocalDate);

                    if (todaysLatestWord != null)
                    {
                        return todaysLatestWord;
                    }
                    Word word = GetRandomWord().Result;

                    var dateWord = new DateWord
                    {
                        Date = localDate,
                        //Date = truelocalDate,
                        Word = word
                    };
                    _db.DateWords.Add(dateWord);
                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (SqlException e) // this is probably not the right error to catch
                    {
                        if (e.Message.Contains("duplicate"))
                        {
                            return _db.DateWords
                                .Include(f => f.Word)
                                .First(f => f.Date == date.Value);
                        }
                    }
                    return dateWord;
                }
            }
        }

        public async Task<List<WordOfTheDayStatsDto>> GetDailyWordStatistics(DateTime? date = null, int daysBack = 10, string? name = null)
        {
            Player? p = await _db.Players.FirstOrDefaultAsync(p => p.Name == name);
            int? playerId;

            if(p is null)
            {
                playerId = null;
            }
            else
            {
                playerId = p.PlayerId;
            }

            if (daysBack < 1 || daysBack > 100) daysBack = 10;

            var startDate = date.HasValue ? date.Value : DateTime.UtcNow.AddHours(-12).Date;
            var endDate = startDate + TimeSpan.FromDays(daysBack * -1);

            
            var result = await _db.DateWords
                .Include(f => f.Plays)
                .Where(f => f.Date <= startDate && f.Date > endDate)
                .OrderByDescending(f => f.Date)
                .Select(f => new WordOfTheDayStatsDto
                {
                    Date = f.Date,
                    AverageSecondsPerGame = f.Plays.Any() ? f.Plays.Average(a => a.TimeInSeconds) : -1,
                    AverageAttempts = f.Plays.Any() ? f.Plays.Average(a => a.Attempts) : -1,
                    NumberOfPlays = f.Plays.Count(),
                    HasUserPlayed = playerId.HasValue ? f.Plays.Any(f => f.PlayerId == playerId.Value) : false
                })
                .ToListAsync();
            
            /*
            var result = await _db.Plays
                .Include(f => f.DateWord)
                .Where(f => f.DateWord != null && f.DateWord.Date <= startDate && f.DateWord.Date >= endDate)
                .GroupBy(f => f.DateWord)
                .Where(f => f.Key != null)
                .Select(g => new WordOfTheDayStatsDto
                {
                    Date = g.Key!.Date,
                    AverageSecondsPerGame = g.Average(f => f.TimeInSeconds),
                    AverageAttempts = g.Average(f => f.Attempts),
                    NumberOfPlays = g.Count(),
                    HasUserPlayed = playerId.HasValue ? g.Any(f => f.PlayerId == playerId.Value) : false
                })
                .ToListAsync();
            */
            if (result.Count != daysBack)
            {
                for (int i = 0; i > (daysBack + 1) * -1; i--)
                {
                    await this.GetWordOfTheDay(TimeSpan.FromHours(12), startDate.AddDays(i));
                }

                result = await GetDailyWordStatistics(date, daysBack);
            }
            return result;
        }

        public async Task<Word> RemoveWord(string? removeWord)
        {
            if (removeWord is null || removeWord.Length != 5)
            {
                throw new ArgumentException("Word must be 5 characters long");
            }
            var word = await _db.Words.FirstOrDefaultAsync(w => w.Text == removeWord);

            if(word == null)
            {
                throw new ArgumentException("Word must be in the Word List");
            }
            
            _db.Words.Remove(word);
            
            await _db.SaveChangesAsync();
            return word;
        }

        public async Task<IEnumerable<Word>> WordList()
        {
            var words = await _db.Words
                .OrderBy(w => w.Text)
                .ToListAsync();
            return words;
        }
    }
}