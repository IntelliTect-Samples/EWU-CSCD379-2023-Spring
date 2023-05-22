using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class WordService
    {
        private readonly AppDbContext _db;
        private static readonly object _WordOfTheDayLock = new();

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
            date ??= DateTime.UtcNow.AddHours(offset.TotalHours).Date;
            var todaysWord = await _db.DateWords
                .Include(f => f.Word)
                .FirstOrDefaultAsync(f => f.Date == date);

            if (todaysWord != null)
            {
                return todaysWord;
            } else
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
                    var word = GetRandomWord().Result;

                    var dateWord = new DateWord
                    {
                        Date = date.Value,
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
                                .First(f => f.Date == date.Value);
                        }
                    }
                    return dateWord;
                }
            }
        }
    }
}