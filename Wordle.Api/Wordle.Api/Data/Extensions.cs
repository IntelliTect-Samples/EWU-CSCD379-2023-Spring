//using Microsoft.AspNetCore.Mvc.RazorPages;
using Wordle.Api.Dtos;

namespace Wordle.Api.Data
{
    public static class Extensions
    {

        public static PlayerResultDto MapToDto(this PlayerResult playerResult)
        {
            PlayerResultDto dto = new()
            {
                PlayerResultId = playerResult.PlayerResultId,
                PlayerId = playerResult.PlayerId,
                PlayerName = playerResult.Player?.Name,
                Attempts = playerResult.Attempts,
                Duration = playerResult.Duration,
                Score = playerResult.Score,
                Success = playerResult.Success,
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
                PlayerResults = player.PlayerResults.Select(x => x.MapToDto()).ToList()
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