using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

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

        //post the daily result
        public async Task<Play> PostDailyResult(PlayDto playDto)
        {
            var play = new Play
            {
                GameDate = DateTime.Now
                //need to add the rest of the properties
            };
            _db.Plays.Add(play);
            await _db.SaveChangesAsync();
            return play;
        }
        
    
    }
}
