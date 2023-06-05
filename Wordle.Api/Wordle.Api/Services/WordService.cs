using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Wordle.Api.Data;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.IdentityModel.Tokens;

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
            IQueryable<AppUser> user = _db.Users.Where(u => u.Name.Equals(userName));
            bool userExists = user.Any();
            
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
                    (userExists) ? _db.Plays.Any((p) => p.UserId == user.First().UserId && p.WordId == wordId) : false,
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

        public async Task<string> GetPageOfWords(int page, string filter)
        {
            IQueryable<Word> words = _db.Words;
         
            if (filter == "" || filter.IsNullOrEmpty())
            {
                // Goal: Return the list of words and a count
                // list o' words
                // count 
                return JsonConvert.SerializeObject(( Math.Ceiling((double)words.Count()/10), JsonConvert.SerializeObject(words.OrderBy(w => w.Text).Skip((page - 1) * 10).Take(10).ToList()))); 
            }
            IEnumerable<Word> filteredWords = words.AsEnumerable()
           .Where(w => Regex.IsMatch(w.Text, $"^{Regex.Escape(filter)}"));

            return JsonConvert.SerializeObject((Math.Ceiling((double)(filteredWords.Count() / 10)), JsonConvert.SerializeObject(filteredWords.OrderBy(w => w.Text).Skip((page - 1) * 10).Take(10).ToList())));


        }

            public async Task<bool> DropWord(string word) {
            IQueryable<Word> words = _db.Words;
            // Get word id 
            IQueryable<Word> subset = words.Where(w => w.Text.Equals(word)); 
            if (!subset.Any()) { return false; }
            Word w = await subset.FirstAsync();
            // Drop it 
            _db.Words.Remove(w);
            //save db
            await _db.SaveChangesAsync();
            return true; 
        }

        public async Task<bool> FlipIsCommon(string word) { 
            IQueryable<Word> words = _db.Words;
            if (!words.Any()) { return false;}
            Word w = (await words.Where(w => w.Text.Equals(word)).FirstAsync());
            w.IsCommon = !w.IsCommon;
            await _db.SaveChangesAsync();
            return true; 
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
                //if it exists already, dont add it
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