using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayersService
    {
        private readonly AppDbContext _db;

        public PlayersService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Players>> GetPlayers()
        {
            return await _db.Players.ToListAsync();
        }
    }
}
