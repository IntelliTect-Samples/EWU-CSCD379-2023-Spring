using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services;

public class LeaderboardService
{
    private readonly AppDbContext _db;

    public LeaderboardService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<double> GetHighScore()
    {
        var highScore = await _db.Players.MaxAsync(player => player.AverageAttempts);
        return highScore;
    }
}
