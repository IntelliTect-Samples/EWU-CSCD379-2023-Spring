namespace Wordle.Api.Dtos
{
    public class DayResultsDto
    {
        public int DaysAgo { get; set; } = 0;
        public int NumPlays { get; set; } = 0;
        public int AvgSeconds { get; set; } = 0;
        public int AvgAttempts { get; set; } = 0;
        public DateTime Date { get; set; }

        public bool DidPlay { get; set; } = false;
    }
}