namespace Wordle.Api.Dtos
{
    public class WordOfTheDayStatsDto
    {
        public DateTime Date { get; set; }
        public double AverageDurationInSeconds { get; set; }
        public double AverageAttempts { get; set; }
        public int NumberOfPlays { get; set; }
        public bool HasUserPlayed { get; set; }
    }
}
