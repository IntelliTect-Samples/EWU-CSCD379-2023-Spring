using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class GameResultService
    {
        private readonly AppDbContext _db;

        public GameResultService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<GameResultDto?> SaveGameResult(GameResult result)
        {
            Player? player = await _db.Players
                .Where(p => p.PlayerId == result.PlayerId)
                .Include(p => p.GameResults)
                .FirstOrDefaultAsync();

            if (player is not null)
            {
                result.CalculateScore();
                player.GameResults.Add(result);
                player.GameCount = player.GameResults.Count();
                player.AverageSecondsPerGame = (int)(player.GameResults.Select(gr => gr.Duration).Average() / 1000);
                player.AverageAttempts = player.GameResults.Select(gr => gr.Attempts).Average();
                await _db.SaveChangesAsync();
                return result.MapToDto();
            }

            return null;
        }

        public async Task<IEnumerable<GameResultDto>> GetTopScores(int count = 10)
        {
            IEnumerable<GameResult> gameResults = await _db.GameResults
                .Where(gr => gr.Success)
                .OrderByDescending(gr => gr.Score)
                .Take(count)
                .Include(gr => gr.Player)
                .ToListAsync();
            return gameResults.Select(gr => gr.MapToDto());
        }
    }
}
