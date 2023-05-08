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

        public async Task<Player?> GetPlayerById(int id) 
        {
            return await _db.Players.FindAsync(id);
        }

        public async Task<bool> RemovePlayer(int id) 
        {
            var player = await _db.Players.FindAsync(id);
            if (player == null) return false;

            _db.Players.Remove(player);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Player> AddOrUpdatePlayerScore(PlayerDto playerDto)
        {
            int Id = playerDto.PlayerId;
            int score = playerDto.Score;
            var player = await _db.Players.FirstOrDefaultAsync(p => p.PlayerId == Id);

            if (player != null)
            {
                player.Score += score;
                player.GameCount += 1;
            }
            else
            {
                throw new ArgumentException("Player not found!");
            }

            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<Player> UpdatePlayerName(UpdateNameDto UpdateNameDto)
        {

            int Id = UpdateNameDto.Id;
            string newName = UpdateNameDto.NewName;

            var player = await _db.Players.FirstOrDefaultAsync(p => p.PlayerId == Id);
            bool nameTaken = await _db.Players.AnyAsync(p => p.Name == newName);

            if (player == null)
            {
                await CreateNewPlayer(newName);
                return player;
            } 
            else if (nameTaken) 
            {
                throw new ArgumentException("New name already taken!, try a different name");
            }
            else 
            {
                player.Name = newName;
                await _db.SaveChangesAsync();
                return player;
            }
        }

        public async Task<Player> CreateNewPlayer(string newName)
        {
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == newName);
            if (player == null)
            {
                player = new Player
                {
                    Name = newName,
                    Score = 0,
                    GameCount = 0,
                    AverageAttempts = 0
                };
                _db.Players.Add(player);
                await _db.SaveChangesAsync();
                return player;
            }
            else
            {
                return player;
            }
        }
    }
}