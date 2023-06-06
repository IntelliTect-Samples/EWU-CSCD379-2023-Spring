using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Identity;
using Wordle.Api.Models;

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

    public async Task<Response<Word>> AddWordAsync(string? newWord, bool isCommon)
    {
        if (newWord is null || newWord.Length != 5)
        {
            return new Response<Word>("Word must be 5 characters long");
        }
        var word = await _db.Words.FirstOrDefaultAsync(w => w.Text == newWord);
        if (word != null)
        {
            return new Response<Word>("Word already exists");
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
        return new Response<Word>(word);
    }

    public async Task<DateWord> GetWordOfTheDayAsync(TimeSpan offset, DateTime? date = null)
    {
        if (date is null)
        {
            date = DateTime.UtcNow.AddHours(offset.TotalHours).Date;
        }

        var todaysWord = await _db.DateWords
          .Include(f => f.Word)
          .FirstOrDefaultAsync(f => f.Date == date.Value.Date);

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
                  .FirstOrDefault(f => f.Date == date.Value);

                if (todaysLatestWord != null)
                {
                    return todaysLatestWord;
                }
                var word = GetRandomWordAsync().Result;

                var dateWord = new DateWord
                {
                    Date = date.Value.Date,
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

    public async Task<List<WordOfTheDayStatsDto>> GetWordOfTheDayStatsAsync(DateTime? date = null, int daysBack = 10, Guid? playerId = null)
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

        //Another way to do this using GroupBy
        //This algorithm doesn't handle days without PlayerGames. 
        // This would need to have the stats inserted into the collection after the fact.
        var result2 = await _db.PlayerGames
          .Include(f => f.DateWord)
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
              NumberOfPlays = g.Count(),
              HasUserPlayed = playerId.HasValue ? g.Any(f => f.PlayerId == playerId.Value) : false

          })
          .ToListAsync();

        // If we don't have enough entries, then we need to add the days.
        if (result.Count != daysBack)
        {
            // We need to add the extra days
            for (int i = 0; i > (daysBack + 1) * -1; i--)
            {
                // Use the timezone that is the worst possible one
                await this.GetWordOfTheDayAsync(TimeSpan.FromHours(12), startDate.AddDays(i));
            }
            // Go get the data again, hopefull this all works and we don't end up in a loop
            result = await GetWordOfTheDayStatsAsync(date, daysBack);
        }
        return result;
    }

    /// <summary>
    /// Get a list of words with search and paging.
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="search"></param>
    /// <returns></returns>
    public async Task<ListResult<IEnumerable<Word>>> GetWords(int pageNumber = 1, int pageSize = 10, string? search = null)
    {
        IQueryable<Word> query = _db.Words;
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(w => w.Text.Contains(search));
        }
        var count = await query.CountAsync();
        // return the last full page
        var totalPages = (int)Math.Ceiling((double)count / pageSize);
        if (pageNumber > totalPages) pageNumber = totalPages;
        if (pageNumber < 1) pageNumber = 1;
        var list = await query
          .OrderBy(w => w.Text)
          .Skip((pageNumber - 1) * pageSize)
          .Take(pageSize)
          .ToListAsync();

        var result = new ListResult<IEnumerable<Word>>(list, count, pageNumber);
        return result;
    }

    public async Task<bool> DeleteWord(int wordId)
    {
        var word = await _db.Words.FindAsync(wordId);
        if (word != null)
        {
            _db.Words.Remove(word);
            await _db.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Word?> UpdateWord(int wordId, string? text, bool isCommon, bool isUsed)
    {
        var word = await _db.Words.FindAsync(wordId);
        if (word != null)
        {
            word.IsCommon = isCommon;
            word.IsUsed = isUsed;
            // Make sure the word is not empty and has a length of 5.
            if (!string.IsNullOrEmpty(text) && text.Length == 5)
            {
                // Make sure the word isn't the current word.
                if (word.Text != text)
                {
                    // Make sure this word doesn't exist anywhere else in the list.
                    if (_db.Words.Count(f => f.Text == text) == 0)
                    {
                        // If all that is true, then change it.
                        word.Text = text;
                    }
                }
            }
            await _db.SaveChangesAsync();
            return word;
        }
        return null;
    }
}