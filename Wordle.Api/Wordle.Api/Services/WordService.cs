using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services;

public class WordService
{
    private readonly AppDbContext _db;
    private static readonly object _WordOfTheDayLock = new object();

    public WordService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Word> GetRandomWordAsync()
    {
        var count = await _db.Words.CountAsync(word => word.IsCommon);
        var index = new Random().Next(count);
        var word = await _db.Words
            .Where(word => word.IsCommon)
            .Skip(index)
            .FirstAsync();
        return word;
    }

    public async Task<IEnumerable<Word>> GetSeveralWordsAsync(int? count)
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

    public async Task<Word> AddWordAsync(string? newWord, bool isCommon)
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

    public async Task<DateWord> GetWordOfTheDayAsync(TimeSpan offset, DateTime? date = null)
    {
        if (date is null)
        {
            date = DateTime.UtcNow;
        }

        var localDateTime = new DateTimeOffset(date.Value.Ticks, offset);
        var localDate = localDateTime.Date;
        var todaysWord = await _db.DateWords
            .Include(f => f.Word)
            .FirstOrDefaultAsync(f => f.Date == localDate);

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

                if (todaysLatestWord != null)
                {
                    return todaysLatestWord;
                }
                var word = GetRandomWordAsync().Result;

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
                catch (SqlException e) // this is probably not the right error to catch
                {
                    if (e.Message.Contains("duplicate"))
                    {
                        return _db.DateWords
                            .Include(f => f.Word)
                            .First(f => f.Date == localDate);
                    }
                }
                return dateWord;
            }
        }
    }

    public async Task<IEnumerable<WordOfTheDayStatsDto>> GetWordOfTheDayStatsAsync
        (DateTime? date = null, int daysBack = 10)
    {
        // Make sure we get the most recent day in the farthest timezone
        var startDate = date.HasValue ? date.Value : DateTime.UtcNow.AddHours(-12).Date;
        var endDate = startDate + TimeSpan.FromDays(daysBack * -1);

        return await _db.PlayerGames
            .Include(f => f.DateWord!.Word)
            .Where(f => f.DateWord != null &&
                f.DateWord.Date <= startDate &&
                f.DateWord.Date >= endDate)
            .GroupBy(f => f.DateWord)
            .Where(f => f.Key != null)
            .Select(g => new WordOfTheDayStatsDto
            {
                Date = g.Key!.Date,
                AverageDurationInSeconds = g.Average(f => f.DurationInSeconds),
                AverageAttempts = g.Average(f => f.Attempts),
                NumberOfPlays = g.Sum(f => f.PlayerGameId)
            })
            .ToListAsync();
    }
}
