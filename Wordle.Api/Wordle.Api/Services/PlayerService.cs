using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        private readonly AppDbContext _context;

        public PlayerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetTop10PlayersAsync()
        {
            return await _context.Players
                .OrderByDescending(p => p.AverageAttempts)
                .Take(10)
                .ToListAsync();
        }

        public async Task<Player> AddOrUpdatePlayerAsync(Player player)
        {
            var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Name == player.Name);

            if (existingPlayer == null)
            {
                _context.Players.Add(player);
            }
            else
            {
                existingPlayer.GameCount = player.GameCount;
                existingPlayer.AverageAttempts = player.AverageAttempts;
            }

            await _context.SaveChangesAsync();

            return player;
        }

        public async Task SeedInitialPlayersAsync()
        {
        
            if (!await _context.Players.AnyAsync())
            {
                
                var initialPlayers = new List<Player>
        {
            new Player { Name = "Meg", GameCount = 5, AverageAttempts = 12.2 },
            new Player { Name = "Grant", GameCount = 7, AverageAttempts = 10.1 },
            new Player { Name = "Mark Michaelis", GameCount = 999, AverageAttempts = 1.0 }
        };

                // Add the initial players to the database
                await _context.Players.AddRangeAsync(initialPlayers);
                await _context.SaveChangesAsync();
            }
        }
    }
}
