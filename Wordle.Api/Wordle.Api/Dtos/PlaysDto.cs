namespace Wordle.Api.Dtos
{
    public class PlaysDto
    {
        public int PlayerId { get; set; }
        public bool WasGameWon { get; set; }
        public int Attempts { get; set; }
        public int TimeInSeconds { get; set; }
        public required string WordPlayed { get; set; }
        public DateTime? WordOfTheDayDate { get; set; }
    }
}
