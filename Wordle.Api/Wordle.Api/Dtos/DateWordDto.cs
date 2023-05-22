namespace Wordle.Api.Dtos
{
    public class DateWordDto
    {
        public ICollection<Guid> PlayerParticipants { get; set; }
        public bool WasGameWon { get; set; }
        public int Attempts { get; set; }
        public int DurationInSeconds { get; set; }
        public required string WordPlayed { get; set; }
        public int TotalAttempts { get; set; }
        public int TotalSeconds { get; set; }
        public int TotalGames { get; set; }

        public double? AverageAttempts()
        {
            if (TotalGames == 0)
            {
                return null; 
            }

            return TotalAttempts / TotalGames;
        }

        public double? AverageSecondsPerGame()
        {
            if (TotalGames == 0)
            {
                return null;
            }

            return TotalSeconds / TotalGames;
        }
    }
}
