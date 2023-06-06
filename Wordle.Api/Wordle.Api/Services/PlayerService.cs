using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Controllers;
using Microsoft.EntityFrameworkCore.Query;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        
        private readonly AppDbContext _db;

        public PlayerService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Player>> GetTopTen()
        {

            var topTen = await _db.Players
                .OrderBy(p => p.AverageAttempts)
                .ThenByDescending(p => p.GameCount)
                .Take(10)
                .ToListAsync();
            return topTen;

        }
        
        public async Task<Player> AddPlayer(string Name, int TotalSecondsPlayed, int TotalAttempts)
        {
            if(Name == null) { throw new ArgumentException("Name can't be null"); }
            var player = await _db.Players.FirstOrDefaultAsync(p =>  p.Name == Name);
            if(player != null) 
            {   
                player.GameCount++;
                player.TotalAttempts += TotalAttempts;
                player.AverageAttempts = player.TotalAttempts / player.GameCount;
                player.TotalSecondsPlayed += TotalSecondsPlayed;
                player.AverageSecondsPerGame = player.TotalSecondsPlayed / player.GameCount;
            }
            else
            {
                
                player = new()
                {
                    Name = Name,
                    GameCount = 1,
                    TotalAttempts = TotalAttempts,
                    AverageAttempts = TotalAttempts,
                    TotalSecondsPlayed = TotalSecondsPlayed,
                    AverageSecondsPerGame = TotalSecondsPlayed
                };
                
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }

        
        public async Task<Player?> GetAsync(int playerId)
        {
            return await _db.Players
                .Where(p => p.PlayerId == playerId)
                .FirstOrDefaultAsync();
        }

        public async Task<Player> CreateAsync(string name)
        {
            Player player = new()
            {
                Name = name,
                //PlayerId = Guid.NewGuid()
            };
            _db.Players.Add(player);
            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<Player> UpdateAsync(int playerId, string name)
        {
            var player = await _db.Players.FindAsync(playerId);
            if (player is not null)
            {
                player.Name = name;
                await _db.SaveChangesAsync();
                return player;
            }
            throw new ArgumentException("Player Id not found");
        }
        

        public async Task<Player?> AddGameResult(string Name, bool WasGameWon, int Attempts, int TimeInSeconds, string WordPlayed, DateTime WordOfTheDayDate)
        {
            await AddPlayer(Name, TimeInSeconds, Attempts);
            var player = await _db.Players.FirstOrDefaultAsync(n => n.Name == Name);

            var word = await _db.Words.FirstOrDefaultAsync(f => f.Text == WordPlayed);

                if (player is not null && word != null)
                {
                    /*
                    if (WasGameWon)
                    {
                    player.AverageAttempts = (player.GameCount * player.AverageAttempts + Attempts) / (player.GameCount + 1);
                    player.AverageSecondsPerGame = (int)(player.AverageSecondsPerGame * player.AverageAttempts + TimeInSeconds) / (player.GameCount + 1);
                    player.GameCount++;
                    }
                    */

                    //var dateWord = await _db.DateWords.FirstOrDefaultAsync(f => WordOfTheDayDate.HasValue && f.Date == WordOfTheDayDate.Value.Date && f.WordId == word.WordId);
                    var dateWord = await _db.DateWords.FirstOrDefaultAsync(f => f.Date == WordOfTheDayDate.Date && f.WordId == word.WordId);

                    Plays play = new()
                    {
                        Player = player,
                        Word = word,
                        Attempts = Attempts,
                        TimeInSeconds = TimeInSeconds,
                        WasGameWon = WasGameWon,
                        DateWord = dateWord,
                        //DateWord = null,
                        Date = DateTime.UtcNow
                        //Date = WordOfTheDayDate
                        //Date = trueDate
                    };

                    /*
                    if (play.Player.Name == "Guest")
                        play.WasGameWon = false;
                    */

                    _db.Plays.Add(play);
                    await _db.SaveChangesAsync();
                    
                    //return play;
                }

            return player;
            throw new ArgumentException("Player Id or Word not found");
        }

        public async Task<Player> GetPlayer(String Name)
        {
            if (Name == null) { throw new ArgumentException("Name can't be null"); }
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == Name);
            if(player != null)
            {
                return player;
            }
            else { throw new ArgumentException("Name must be in the database"); }
        }
    }
}
