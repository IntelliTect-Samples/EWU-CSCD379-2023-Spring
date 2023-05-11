namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public int TotalAttempts { get; set; }
        public double AverageAttempts { get; set; }
        public int TotalSecondsPlayed { get; set; }
        public int AverageSecondsPerGame { get; set; }

    }
}