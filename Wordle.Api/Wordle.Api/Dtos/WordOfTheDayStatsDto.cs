namespace Wordle.Api.Dtos
{
    public class WordOfTheDayStatsDto
    {
        public DateTime Date { get; set; }
        public double AvgTime { get; set; }
        public double AvgAttempts { get; set; }
        public int NumberOfPlays { get; set; }
        public bool HasUserPlayed { get; set; }
    }
}
