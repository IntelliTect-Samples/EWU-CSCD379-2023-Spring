namespace Wordle.Api.Data
{
    public class DateWord
    {
        public int DateWordId { get; set; }
        public DateTime Date { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; } = null!;

        public ICollection<PlayerGame> PlayerGames { get; } = null!;
    }
}

