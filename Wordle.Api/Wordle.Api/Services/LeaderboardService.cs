using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Wordle.Api.Data;

namespace Wordle.Api.Services;

public class LeaderboardService
{
    private readonly AppDbContext _db;

    public LeaderboardService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Player>> GetTopTenScores()
    {
        var highScore = await _db.Players.Take(10)
                            .OrderByDescending(player => player.AverageTimeInSeconds)
                            .ToListAsync();
        return highScore;
    }

    // Retrieve a the stats of a specified player, passed by name as parameter
    public async Task<IEnumerable<Player>> GetPlayerStats(string playerName)
    {
        var player =
            await _db.Players.Select(p => p).Where(p => p.PlayerName == playerName).ToListAsync();

        if (player == null)
        {
            throw new ArgumentNullException("Player is null");
        }

        return player;
    }

    public async Task<Player> AddNewPlayer(string? playerName, int timeInSeconds, double attempts)
    {
        var name = "";
        if (playerName is null || playerName == "")
        {
            name = "Guest";
        }
        else
        {
            name = playerName;
        }
        var player = await _db.Players.FirstOrDefaultAsync(p => p.PlayerName == playerName);
        if (player != null)
        {
            player = await UpdatePlayer(name, timeInSeconds, attempts);
            //_db.Players.Update(player);
        }
        else
        {
            player = new() {
                PlayerName = name,          GameCount = 1,
                TotalAttempts = attempts,   TotalTimeInSeconds = timeInSeconds,
                AverageAttempts = attempts, AverageTimeInSeconds = timeInSeconds,
            };
            _db.Players.Add(player);
        }
        await _db.SaveChangesAsync();
        return player;
    }

    private async Task<Player> UpdatePlayer(string playerName, int timeInSeconds, double attempts)
    {
        var player =
            await _db.Players.FirstOrDefaultAsync(player => player.PlayerName == playerName);
        player!.GameCount += 1;
        player.TotalTimeInSeconds += timeInSeconds;
        player.TotalAttempts += attempts;
        player.AverageAttempts = player.TotalAttempts / player.GameCount;
        player.AverageTimeInSeconds = player.TotalTimeInSeconds / player.GameCount;

        return player;
    }
}
