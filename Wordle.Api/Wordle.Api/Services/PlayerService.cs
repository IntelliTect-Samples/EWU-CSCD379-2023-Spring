using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        private readonly AppDbContext _db;

        public PlayerService(AppDbContext db)
        {
            _db = db;
        }

        public Player[] GetTop10() {
            return  _db.Players.OrderBy(player => player.AverageAttempts).Take(10).ToArray();  
        }
    }
}
