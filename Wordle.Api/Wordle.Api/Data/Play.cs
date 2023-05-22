namespace Wordle.Api.Data
{
    public class Play
    {
        public int Id { get; set; }
        public Guid PlayerId { get; set; }
        public required Player Player { get; set; }
        public int WordId { get; set; }
        public required Word Word { get; set; }
        public int DailyWordId { get; set; }
        public DateWord? DailyWord { get; set; }
        public int Attempts { get; set; }
        public int Score { get; set; }
        public int DurationInSeconds { get; set; }
        public DateTime? GameDate { get; set; }
        public bool WasGameWon { get; set; }
    }
}
