using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Timer = System.Timers.Timer;
using System.Timers;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class WordService
    {
        private readonly AppDbContext _db;
        private Word TodaysWord;
        private readonly List<string> PreviousWords;

        public WordService(AppDbContext db)
        {
            _db = db;
            PreviousWords = new List<string>();
            TodaysWord = new Word { Text = GetRandomWord().Result };
            StartTimer();
        }

        public async Task<string> GetRandomWord()
        {
            if (TodaysWord.Text.IsNullOrEmpty())
            {
                do
                {
                    var count = await _db.Words.CountAsync(word => word.IsCommon);
                    var index = new Random().Next(count);
                    TodaysWord = await _db.Words
                        .Where(word => word.IsCommon)
                        .Skip(index)
                        .FirstAsync();
                } while (PreviousWords.Contains(TodaysWord.Text));
            }
            return TodaysWord.Text;
            
        }

        public string[] GetPreviousWords()
        {
            if (PreviousWords.Count >= 10)
                return PreviousWords.TakeLast(10).ToArray();
            return PreviousWords.ToArray();
        }

        private void StartTimer()
        {
            TimeSpan day = new TimeSpan(24, 00, 00);
            TimeSpan now = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
            TimeSpan activationTime = new TimeSpan(0, 0, 0);
            TimeSpan timeLeftUntilFirstRun = day - now + activationTime;
            if (timeLeftUntilFirstRun.TotalHours > 24)
                timeLeftUntilFirstRun -= new TimeSpan(24, 0, 0);

            Timer execute = new Timer();
            execute.Interval = timeLeftUntilFirstRun.TotalMilliseconds;
            execute.Elapsed += ResetWord;
            execute.Start();
        }

        private void ResetWord(object? sender, ElapsedEventArgs e)
        {
            PreviousWords.Add(TodaysWord.Text);
            TodaysWord.Text = "";

            if (sender is not null)
            {
                TimeSpan day = new TimeSpan(24, 00, 00);
                TimeSpan now = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
                TimeSpan activationTime = new TimeSpan(0, 0, 0);
                TimeSpan timeLeftUntilNextRun = day - now + activationTime;
                if (timeLeftUntilNextRun.TotalHours > 24)
                    timeLeftUntilNextRun -= new TimeSpan(24, 0, 0);

                Timer execute = (Timer)sender;
                execute.Interval = timeLeftUntilNextRun.TotalMilliseconds;
            }
            else
                throw new ArgumentNullException(nameof(sender));
            
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