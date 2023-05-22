using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services;

public class WordService
{
    private readonly AppDbContext _db;
    private static readonly object s_wordOfTheDayLock = new object();

    public WordService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Word> GetRandomWord()
    {
        var count = await _db.Words.CountAsync(word => word.IsCommon);
        var index = new Random().Next(count);
        var word = await _db.Words.Where(word => word.IsCommon).Skip(index).FirstAsync();
        return word;
    }

    public async Task<string> GetWordOfTheDay(TimeSpan offset, DateTime? date = null)
    {
        date ??= DateTime.UtcNow;

        var localDateTime = new DateTimeOffset(date.Value.Ticks, offset);
        var localDate = localDateTime.Date;
        var todaysWord =
            await _db.DateWords.Include(f => f.Word).FirstOrDefaultAsync(f => f.Date == localDate);

        if (todaysWord != null)
        {
            return todaysWord.Word.Text;
        }
        lock (s_wordOfTheDayLock)
        {
            var todaysLatestWord =
                _db.DateWords.Include(f => f.Word).FirstOrDefault(f => f.Date == localDate);

            if (todaysLatestWord != null)
            {
                return todaysLatestWord.Word.Text;
            }
            var word = GetRandomWord().Result;

            var dateWord = new DateWord { Date = localDate, Word = word };
            _db.DateWords.Add(dateWord);
            try
            {
                _db.SaveChanges();
            }
            catch (SqlException e)  // this is probably not the right error to catch
            {
                if (e.Message.Contains("duplicate"))
                {
                    return _db.DateWords.Include(f => f.Word)
                        .First(f => f.Date == localDate)
                        .Word.Text;
                }
            }
            return word.Text;
        }
    }

    public async Task<List<string>> GetWordList()
    {
        return await _db.Words.Select(word => word.Text).ToListAsync();
    }
}
