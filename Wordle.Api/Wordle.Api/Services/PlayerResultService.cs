using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class PlayerResultService
    {
        private readonly AppDbContext _db;

        public PlayerResultService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<PlayerResultDto?> SaveGameResult(PlayerResultDto playerResultDto)
        {
            Player? player = await _db.Players
                .FirstOrDefaultAsync(p => p.PlayerId == playerResultDto.PlayerId);

            if (player is not null)
            {
                PlayerResult playerResult = new PlayerResult
                {
                    PlayerId = playerResultDto.PlayerId,
//                    Word = playerResultDto.Word,
                    Attempts = playerResultDto.Attempts,
                    Duration = playerResultDto.Duration
                };
                playerResult.CalculateScore();
                player.PlayerResults.Add(playerResult);
                player.GameCount = player.PlayerResults.Count();
                player.AverageSecondsPerGame = (int)(player.PlayerResults.Select(gr => gr.Duration).Average() / 1000);
                player.AverageAttempts = player.PlayerResults.Select(gr => gr.Attempts).Average();
                await _db.SaveChangesAsync();
                return playerResult.MapToDto();
            }

            return null;
        }

        public async Task<IEnumerable<PlayerResultDto>> GetTopScores(int count = 10)
        {
            IEnumerable<PlayerResultDto> topScores = await _db.PlayerResults
                .Include(gr => gr.Player)
                .Where(gr => gr.Success)
                .OrderByDescending(gr => gr.Score)
                .Take(count)
                .Select(gr => gr.MapToDto())
                .ToListAsync();

            return topScores;
        }

        public async Task<IEnumerable<PlayerResultDto>> GetAllGameResults()
        {
            IEnumerable<PlayerResultDto> playerResults = await _db.PlayerResults
                .Include(gr => gr.Player)
                .OrderByDescending(gr => gr.Score)
                .Select(gr => gr.MapToDto())
                .ToListAsync();

            return playerResults;
        }
    }
}
