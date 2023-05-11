namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public string? Name { get; set; }
        public double NumberOfAttempts { get; set; }
        public int ElapsedSeconds { get; set; }
    }
}