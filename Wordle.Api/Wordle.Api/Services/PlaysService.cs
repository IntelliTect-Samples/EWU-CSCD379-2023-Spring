using System.Collections.Immutable;
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
            /*
            //exception catching
            var words = await _db.Words.FirstOrDefaultAsync(w => w.WordId == WordId);
            var plays = await _db.Players.FirstOrDefaultAsync(p => p.PlayerId == PlayerId);

            if (words == null)
            {
                throw new ArgumentException("Must be a valid word!");
            }
            else if(plays == null)
            {
                throw new ArgumentException("Must be a valid player!");
            }
            */

            var word = await _db.Plays.FirstOrDefaultAsync(p => p.WordId == WordId);
            if(word != null)
            {
                var count = 0;
                for(int i = 0; i < word.PlayerIds.Count; i++)
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
                    word.PlayerIds.Append<int>(PlayerId);
                }

                for(int i = 0; i < word.PlayerIds.Count; i++)
                {
                    var player = await _db.Players.FirstOrDefaultAsync(p => p.PlayerId == word.PlayerIds[i]);
                    word.GrandTotalGames += player.GameCount;
                    word.GrandTotalAttempts += player.TotalAttempts;
                    word.GrandAverageAttempts = word.GrandTotalAttempts / word.GrandTotalGames;
                    word.GrandTotalTime += player.TotalSecondsPlayed;
                    word.GrandAverageTime = word.GrandTotalTime / word.GrandTotalGames;
                }
            }
            else
            {
                var player = await _db.Players.FirstOrDefaultAsync(p => p.PlayerId == PlayerId);
                var date = await _db.DateWords.FirstOrDefaultAsync(d => d.WordId == WordId);
                word = new()
                {
                    WordId = WordId,
                    Date = date.Date,
                    PlayerIds = new List<int>(PlayerId),
                    GrandTotalGames = player.GameCount,
                    GrandTotalAttempts = player.TotalAttempts,
                    GrandTotalTime = player.TotalSecondsPlayed,
                    GrandAverageTime = player.TotalSecondsPlayed
                };
                _db.Plays.Add(word);
            }
            await _db.SaveChangesAsync();
            return word;
        }

        public async Task<IEnumerable<Plays>> GetDailyWordStatistics(int? count)
        {
            count ??= 10;
            var pastTen = await _db.Plays
                .OrderByDescending(p => p.Date)
                .Take(10)
                .ToListAsync();
            return pastTen;
        }
    }
}