using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class WordService
    {
        private readonly AppDbContext _db;

        private record WordStatistics(
            string Date, 
            string Word, 
            bool IsPlayed, 
            int GameCount, 
            double AvgAttempts, 
            double AvgSeconds
            );

        public WordService(AppDbContext db)
        {
            _db = db;
        }

        private async Task<WordStatistics> GetWordStats(string userName, DateTime date) {
            string word = await GetWordOfDay(date); 
            // Take a word as input and return the following: # of games that have been played
            int wordId = _db.Words.Where((w) => w.Text.Equals(word)).First().WordId;
            int userId = _db.Users.Where((u) => u.Name.Equals(userName)).First().UserId;
            IQueryable<Play> play = _db.Plays.Where(p => wordId == p.WordId);
            // Get the current date
            DateTime currentDate = date;
            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;

            // Convert to a string
            string dateString = string.Format("{0}/{1}/{2}", month, day, year);
            bool playExists = play.Any(); 
            WordStatistics wordStatistics = new(
                    // Date
                    dateString,
                    // Word
                    word,
                    //IsPlayed: If Exists a row in which the playerId
                    _db.Plays.Any((p) => p.UserId == userId && p.WordId == wordId),
                    // GameCount
                    playExists ? play.Count() : 0,
                    // AvgAttempts 
                    playExists ? play.Average(p => p.Attempts) : 0,
                    playExists ? play.Average(p => p.Attempts) : 0
                ) ; 
            return wordStatistics;
            

        
        }

        public async Task<string> GetWordOfDayLastTenDays(string userName) {
            List<WordStatistics> wordOfDayTenDays = new ();  
            for (int i = 0; i > -10; i--) {
      
                wordOfDayTenDays.Add(await GetWordStats(userName, DateTime.Now.AddDays(i)));


            }
            return JsonConvert.SerializeObject(wordOfDayTenDays); 
        }

        public async Task<string> GetWordOfDay(DateTime date) {
            // Get the current date
            DateTime currentDate = date;
            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;

            // Convert to a string
            string dateString = string.Format("{0}/{1}/{2}", year, day, month);
            // Hash the string
            int hashCode; 
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(dateString));
                hashCode = BitConverter.ToInt32(hashBytes, 0);
   
            }
            // Mod by the number of words 
            var count = await _db.Words.CountAsync(word => word.IsCommon);
            int index = Math.Abs(hashCode % count);
            // Return the word as text
            return (await _db.Words
                .Where(word => word.IsCommon)
                .Skip(index)
                .FirstAsync()).Text;
            

        }

        public async Task<string> GetRandomWord()
        {
            var count = await _db.Words.CountAsync(word => word.IsCommon);
            var index = new Random().Next(count);
            var word = await _db.Words
                .Where(word => word.IsCommon)
                .Skip(index)
                .FirstAsync();
            return word.Text;
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
    }
}