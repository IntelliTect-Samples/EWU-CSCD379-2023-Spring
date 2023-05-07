namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }

        // Initialize Name with an empty string
        public string Name { get; set; } = string.Empty;

        public int Score { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
    }
}