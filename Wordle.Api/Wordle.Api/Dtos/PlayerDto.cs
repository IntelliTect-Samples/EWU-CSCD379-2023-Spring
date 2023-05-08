namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
        public double? AverageSecondsPerGame { get; set; }
    }
}

