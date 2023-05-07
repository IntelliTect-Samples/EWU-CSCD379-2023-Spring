﻿namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public int? PlayerId { get; set; }
        public string? Name { get; set; }
        public int? GameCount { get; set; }
        public double? AverageAttempts { get; set; }
        public int? AverageSecondsPerGame { get; set; }
        public List<GameResultDto>? GameResults { get; set; } = new List<GameResultDto>();
    }
}
