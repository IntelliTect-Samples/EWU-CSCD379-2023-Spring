using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Runtime.InteropServices;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        private readonly AppDbContext _db;

        public PlayerService(AppDbContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Player>> GetTopPlayersAsync(int count = 10)
        {
            return await _db.Players
                .Where(p=>p.GameCount > 0)
                .OrderBy(f=>f.AverageAttempts)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Player?> GetAsync(Guid playerId)
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
                PlayerId = Guid.NewGuid()
            };
            _db.Players.Add(player);
            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<Play> AddGameResultAsync(GameResultDto dto)
        {
            var player = await _db.Players.FindAsync(dto.PlayerId);
            var word = await _db.Words.FirstOrDefaultAsync(w => w.Text == dto.WordPlayed);

            if (player is not null && word != null)
            {
                if (dto.WasGameWon)
                {
                    player.AverageAttempts = (player.GameCount * player.AverageAttempts + dto.Attempts) / (player.GameCount + 1);
                    player.AverageSecondsPerGame = (int)(player.AverageSecondsPerGame * player.AverageAttempts + dto.DurationInSeconds) / (player.GameCount + 1);
                    player.GameCount++;
                }

                var dateWord = await _db.DateWords.FirstOrDefaultAsync(d => dto.WordOfTheDayDate.HasValue && d.Date == dto.WordOfTheDayDate.Value.Date && d.WordId == word.WordId);

                Play play = new()
                {
                    Player = player,
                    Word = word,
                    Attempts = dto.Attempts,
                    DurationInSeconds = dto.DurationInSeconds,
                    WasGameWon = dto.WasGameWon,
                    DailyWord = dateWord,
                    GameDate = DateTime.UtcNow
                };
                _db.Plays.Add(play);
                await _db.SaveChangesAsync();
                return play;
            }
            throw new ArgumentException("Player Id not found");
        }

        public async Task<Player> UpdateAsync(Guid playerId, string name)
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
    }
}
