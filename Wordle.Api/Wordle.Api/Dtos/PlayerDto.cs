using Wordle.Api.Data;

namespace Wordle.Api.Dtos;

public class PlayerDto
{
    public Guid? PlayerId { get; set; }
    public string? PlayerName { get; set; }
    public int? GameCount { get; set; }
    public double? AverageAttempts { get; set; }
    public int? AverageSecondsPerGame { get; set; }

    public PlayerDto()
    { }

    public PlayerDto(Player player)
    {
        PlayerId = player.PlayerId;
        PlayerName = player.PlayerName;
        GameCount = player.GameCount;
        AverageAttempts = player.AverageAttempts;
        AverageSecondsPerGame = player.AverageSecondsPerGame;
    }

    public class CreatePlayerDto
    {
        public required string Name { get; set; }
    }
}
