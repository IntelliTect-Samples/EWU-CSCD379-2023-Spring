namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public int? PlayerId { get; set; }
        public required string Name { get; set; }
        public int? GameCount { get; set; }
        public double AverageAttempts { get; set; }
        public int AverageSecondsPerGame { get; set; }
    }
}