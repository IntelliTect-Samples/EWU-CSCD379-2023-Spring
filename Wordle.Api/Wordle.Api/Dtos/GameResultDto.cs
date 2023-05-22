namespace Wordle.Api.Dtos
{
    public class GameResultDto
    {
        public Guid PlayerId { get; set; }
        public bool WasGameWon { get; set; }
        public int Attempts { get; set; }
        public int DurationInSeconds { get; set; }
        public required string WordPlayed { get; set; }
        public DateTime? WordOfTheDayDate { get; set; }
    }
}
