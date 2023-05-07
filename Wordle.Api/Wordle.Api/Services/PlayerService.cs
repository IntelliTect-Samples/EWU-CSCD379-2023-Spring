using Microsoft.AspNetCore.Mvc;
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


        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _db.Players.ToListAsync();
        }

        public async Task<Player?> GetPlayer(int playerId)
        {
            return await _db.Players
                .Where(p => p.PlayerId == playerId)
                .Include(p => p.GameResults)
                .FirstOrDefaultAsync();
        }

        public async Task<Player> CreatePlayer()
        {
            Player player = new() { Name = "Guest" };
            await _db.Players.AddAsync(player);
            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<Player?> ChangeName(int playerId, string playerName)
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
