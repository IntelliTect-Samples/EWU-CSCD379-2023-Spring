using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        
        private readonly Players _db;

        public PlayerService(Players db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Player>> GetPlayer()
        {
            
        }

    }
}