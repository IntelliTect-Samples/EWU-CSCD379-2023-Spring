using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class DateWordStatsDto
    {
        public DateWordStatsDto(DateWordStats dateWordStats)
        {
            DateWordStatsId = dateWordStats.DateWordStatsId;
            averageScore = dateWordStats.averageScore;
            averageTime = dateWordStats.averageTime;
            totalTime = dateWordStats.totalTime;
            numberOfPlays = dateWordStats.numberOfPlays;
        }

        public int DateWordStatsId { get; set; }
        public double averageScore { get; set; }
        public double averageTime { get; set; }
        public int totalTime { get; set; }
        public int numberOfPlays { get; set; }
    }
}
