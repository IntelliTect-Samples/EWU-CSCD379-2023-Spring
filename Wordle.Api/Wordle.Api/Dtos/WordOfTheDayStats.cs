namespace Wordle.Api.Dtos
{
    public class WordOfTheDayStatsDto
    {
        public DateTime Date { get; set; }
        public double AverageSecondsPerGame { get; set; }
        public double AverageAttempts { get; set; }
        public int Plays { get; set; }
        public bool HasPlayed { get; set; }
    }
}