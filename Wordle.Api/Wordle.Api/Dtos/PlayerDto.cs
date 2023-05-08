namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public int? PlayerId { get; set; }
        public string? Name { get; set; }
        public int? GameCount { get; set; }
        public double? AverageAttempts { get; set; }
        public int? AverageSecondsPerGame { get; set; }
        public List<PlayerResultDto>? PlayerResults { get; set; } = new List<PlayerResultDto>();
    }
}