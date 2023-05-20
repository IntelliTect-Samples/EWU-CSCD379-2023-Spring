namespace Wordle.Api.Data
{
    public class Play
    {
        public Guid Id { get; set; }
        public Boolean HasPlayed { get; set; }
        public int PlayerId { get; set; }
        public int WordId { get; set; }
        public DateTime GameDate { get; set; }
        public int NumberOfPlays { get; set; }
        public int AvgScore { get; set; }
        public int AvgTime { get; set; }

    }
}
