using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayService
    {
        private readonly AppDbContext _db;

        public PlayService(AppDbContext db)
        {
            _db = db;
        }


        //get the last 10 game dates
        public async Task<List<Play>> GetLastTenDates()
        {
            return await _db.Plays
                .OrderByDescending(d => d.GameDate)
                .Take(10)
                .ToListAsync();
        }
        
    
    }
}
