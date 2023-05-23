using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public PlayerDto() { }
        public PlayerDto(Player player)
        {
            PlayerId = player.PlayerId;
            Name = player.Name;
            GameCount = player.GameCount;
            AverageAttempts = player.AverageAttempts;
            AverageSecondsPerGame = player.AverageSecondsPerGame;
        }

        public Guid? PlayerId { get; set; }
        public string? Name { get; set; }
        public int? GameCount { get; set; }
        public double? AverageAttempts { get; set; }
        public int? AverageSecondsPerGame { get; set; }

        
    }

    public class CreatePlayerDto
    {
        public required string Name { get; set; }
    }
}
