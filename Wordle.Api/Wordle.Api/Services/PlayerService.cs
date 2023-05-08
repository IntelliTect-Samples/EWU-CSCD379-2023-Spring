using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            return await _db.Players.ToListAsync();
        }

        public async Task<Player> CreatePlayerAsync()
        {
            var player = new Player { Name = "Guest" };
            _db.Players.Add(player);
            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<Player?> GetPlayerAsync(int playerId)
        {
            return await _db.Players
                .Include(p => p.PlayerResults)
                .FirstOrDefaultAsync(p => p.PlayerId == playerId);
        }

        public async Task<Player?> ChangeNameAsync(int playerId, string playerName)
        {
            var player = await _db.Players.FindAsync(playerId);
            if (player is not null)
            {
                player.Name = playerName;
                await _db.SaveChangesAsync();
            }
            return player;
        }

        public async Task<PlayerDto?> Update(PlayerDto dto)
        {
            var player = await _db.Players.FindAsync(dto.PlayerId);
            if (player is not null)
            {
                player.UpdateFromDto(dto);
                await _db.SaveChangesAsync();
                return player.MapToDto();
            }
            return null;
        }
    }
}
