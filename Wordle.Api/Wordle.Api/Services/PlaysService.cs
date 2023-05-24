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

        public async Task<Plays> AddGameResult(PlaysDto dto)
        {
            var player = await _db.Players.FindAsync(dto.PlayerId);
            var word = await _db.Words.FirstOrDefaultAsync(f => f.Text == dto.WordPlayed);
            if (player is not null && word != null)
            {
                if (dto.WasGameWon)
                {
                    player.AverageAttempts = (player.GameCount * player.AverageAttempts + dto.Attempts) / (player.GameCount + 1);
                    player.AverageSecondsPerGame = (int)(player.AverageSecondsPerGame * player.AverageAttempts + dto.TimeInSeconds) / (player.GameCount + 1);
                    player.GameCount++;
                }

                var dateWord = await _db.DateWords.FirstOrDefaultAsync(f => dto.WordOfTheDayDate.HasValue && f.Date == dto.WordOfTheDayDate.Value.Date && f.WordId == word.WordId);

                Plays play = new()
                {
                    Player = player,
                    Word = word,
                    Attempts = dto.Attempts,
                    TimeInSeconds = dto.TimeInSeconds,
                    WasGameWon = dto.WasGameWon,
                    DateWord = dateWord,
                    Date = DateTime.UtcNow
                };
                _db.Plays.Add(play);
                await _db.SaveChangesAsync();

                return play;
            }

            throw new ArgumentException("Player Id or Word not found");
        }
    }
}