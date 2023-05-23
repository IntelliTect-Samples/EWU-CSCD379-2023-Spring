using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class PlaysService
    {
        private readonly AppDbContext _db;

        public PlaysService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Plays> AddPlay(int WordId, int PlayerId)
        {
            if(WordId != await _db.Words.FirstOrDefaultAsync(w => w.WordId == WordId))
            {
                throw new ArgumentException("Must be a valid word!");
            }
            else if(PlayerId != await _db.Players.FirstOrDefaultAsync(p => p.PlayerId == PlayerId))
            {
                throw new ArgumentException("Must be a valid player!");
            }

            var word = await _db.Plays.FirstOrDefaultAsync(p => p.WordId == WordId);
            if(word != null)
            {
                var count = 0;
                for(int i; i < word.PlayerIds.length; i++)
                {
                    if (word.PlayerIds[i] == PlayerId)
                    {
                        count ++;
                    }

                    if(count > 0)
                    {
                        break;
                    }
                }

                if(count == 0)
                {
                    word.PlayerIds.append(word.PlayerId);
                }

                for(int i; i < word.PlayerIds.length; i++)
                {
                    var player = await _db.Player.FirstOrDefaultAsync(p => p.PlayerId == word.PlayerIds[i]);
                    word.GrandTotalGames += player.GameCount;
                    word.GrandTotalAttempts += player.TotalAttempts;
                    word.GrandAverageAttempts = word.GrandTotalAttempts / word.GrandTotalGames;
                    word.GrandTotalTime += player.TotalSecondsPlayed;
                    word.GrantAverageTime = word.GrandTotalTime / word.GrandTotalGames;
                }
            }
            else
            {
                var player = await _db.Player.FirstOrDefaultAsync(p => p.PlayerId == PlayerId)
                word = new()
                {
                    WordId = WordId,
                    PlayerIds(0) = PlayerId,
                    GrandTotalGames = player.GameCount,
                    GrandTotalAttempts = player.TotalAttempts,
                    GrandTotalTime = player.TotalSecondsPlayed,
                    GrandAverageTime = player.TotalSecondsPlayed
                }
                _db.Plays.Add(word);
            }
            await _db.SaveChangesAsync();
            return word;
        }

        public async Task<IEnumerable<Plays>> GetDailyWordStatistics()
        {
            var pastTen = await _db.Plays
                .OrderBy(p => p.WordId)
                .Take(10)
                .ToListAsync();
            return pastTen;
        }
    }
}