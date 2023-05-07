using Wordle.Api.Dtos;

namespace Wordle.Api.Data
{
    public static class Extensions
    {

        public static GameResultDto MapToDto(this GameResult gameResult)
        {
            GameResultDto dto = new()
            {
                GameResultId = gameResult.GameResultId,
                PlayerId = gameResult.PlayerId,
                PlayerName = gameResult.Player?.Name,
                Attempts = gameResult.Attempts,
                Duration = gameResult.Duration,
                Score = gameResult.Score,
                Success = gameResult.Success,
            };

            return dto;
        }
        public static PlayerDto MapToDto(this Player player)
        {
            PlayerDto dto = new()
            {
                PlayerId = player.PlayerId,
                Name = player.Name,
                GameCount = player.GameCount,
                AverageAttempts = player.AverageAttempts,
                AverageSecondsPerGame = player.AverageSecondsPerGame,
                GameResults = player.GameResults.Select(x => x.MapToDto()).ToList()
            };
            return dto;
        }

        public static void UpdateFromDto(this Player player, PlayerDto dto)
        {
            if (dto.Name is not null)
            {
                player.Name = dto.Name;
            }
        }
    }
}
