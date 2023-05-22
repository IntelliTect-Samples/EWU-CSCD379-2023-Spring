namespace Wordle.Api.Data
{
    public class DateWordStats
    {
        public int DateWordStatsId { get; set; }
        public double averageScore { get; set; }
        public double averageTime { get; set; }
        public int totalTime { get; set; }
        public int numberOfPlays { get; set; }

    }
}
