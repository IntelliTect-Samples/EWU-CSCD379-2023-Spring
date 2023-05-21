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

        public async Task<IEnumerable<DayResultsDto>> GetLastTenDays(TimeSpan offset, Guid playerId, DateTime? date = null)
        {
            
            date = DateTime.UtcNow;//force date = now
            
            var localDateTime = new DateTimeOffset(date.Value.Ticks, offset);//local date
            
            List<DayResultsDto> lastTenDays = new List<DayResultsDto>();//list of days to be returned

            for (var i = 0; i < 10; i++)//for the last ten days
            {
                var localDate = localDateTime.Date.AddDays(-i);//day minus days to check backwards

                //Was there a word on that day
                var wordOfThatDay = await _db.DateWords
                    .Include(f => f.Word)
                    .FirstOrDefaultAsync(f => f.Date == localDate);

                if (wordOfThatDay != null)
                {//if there was a game played, get the results
                    var dayPlays = await _db.Plays
                        .Where(plays => plays.Date == localDate)
                        .ToListAsync();
                    
                    var didPlay = await _db.Plays
                        .AnyAsync(plays => plays.PlayerId == playerId);
                    if(dayPlays.Count > 0)
                    {
                        var dayResults = new DayResultsDto()
                        {//word exists and has plays
                            NumPlays = dayPlays.Count,
                            AvgSeconds = (int)dayPlays.Average(plays => plays.Seconds),
                            AvgAttempts = (int)dayPlays.Average(plays => plays.Attempts),
                            Date = localDate,
                            DidPlay = true
                        };
                        lastTenDays.Add(dayResults);
                    } else
                    {//word existed but nobody played it
                        var dayResults = new DayResultsDto()
                        {
                            Date = localDate
                        };
                        lastTenDays.Add(dayResults);
                    }
                    
                }else
                {//game was not played this day
                    var dayResults = new DayResultsDto()
                    {
                        Date = localDate
                    };
                    lastTenDays.Add(dayResults);
                }
            }
            return lastTenDays;
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