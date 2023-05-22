namespace Wordle.Api.Data
{
    public class PlayerGame
    {
        public int PlayerGameId { get; set; }
        public Guid PlayerId { get; set; }
        public required Player Player { get; set; }
        public int WordId { get; set; }
        public required Word Word { get; set; }
        public int? DateWordId { get; set; }
        public DateWord? DateWord { get; set; }
        public int Attempts { get; set; }
        public int DurationInSeconds { get; set; }
        public DateTime Date { get; set; }
        public bool WasGameWon { get; set; }
    }
}
