using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Wordle.Api.Data;

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
            var index = new System.Random().Next(count);
            var word = await _db.Words.Where(word => word.IsCommon).Skip(index).FirstAsync();
            return word;
        }

        public async Task<string> GetWordOfTheDay(TimeSpan offset, DateTime? date = null)
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
                return todaysWord.Word.Text;
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
                    catch (SqlException ex) // Might be wronge exception
                    {
                        if (ex.Message.Contains("duplicate"))
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

        public async Task<List<Word>> GetAllWords() 
        {
            return await _db.Words.OrderBy(word => word.Text).ToListAsync();
        }
        public async Task<string[]> GetAllIsCommon()
        {
            var words = await _db.Words.OrderBy(word => word.Text).ToArrayAsync();

            var wordArray = new string[words.Length];
            var count = 0;

            foreach (var word in words)
            {
                wordArray[count] = $"{words[count].IsCommon}";
                count++;
            }

            return wordArray;
        }

        public async Task<Word> AddWord(string newWord, bool isCommon) 
        {
            string text = newWord.ToLower();
            Word? word = await _db.Words.FirstOrDefaultAsync(word => word.Text == text);

            if (word == null) 
            {
                word = new()
                {
                    Text = text,
                    IsCommon = isCommon
                };
                _db.Words.Add(word);
            }
            await _db.SaveChangesAsync();
            return word;
        }

        public async Task<Word?> UpdateWord(string newWord, bool isCommon) 
        {
            string text = newWord.ToLower();
            Word? word = await _db.Words.FirstOrDefaultAsync(word => word.Text == text);

            if (word != null && isCommon != word.IsCommon) 
            { 
                word.IsCommon= isCommon;
            }
            await _db.SaveChangesAsync();
            return word;
        }

        public async Task<Word?> DeleteWord(string newWord)
        {
            string text = newWord.ToLower();
            Word? word = await _db.Words.FirstOrDefaultAsync(word => word.Text == text);

            if (word != null) 
            { 
                _db.Words.Remove(word); 
            }
            await _db.SaveChangesAsync();
            return word;
        }
    }
}