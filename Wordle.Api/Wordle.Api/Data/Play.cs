namespace Wordle.Api.Data
{
    public class Play
    {
        public Guid Id { get; set; }
        public bool HasPlayed { get; set; }
        public int PlayerId { get; set; }
        public DateWord? DailyWord { get; set; }
        public DateTime? GameDate { get; set; }
        public int NumberOfPlays { get; set; }
        public int AvgScore { get; set; }
        public int AvgTime { get; set; }

    }
}
