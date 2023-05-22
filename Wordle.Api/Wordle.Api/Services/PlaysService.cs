using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class PlaysService
    {
        private readonly AppDbContext _db;

        public PlaysService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Plays> AddPlay()
        {

        }

        public async Task<IEnumerable<Plays>> GetDailyWordStatistics()
        {

        }
    }
}