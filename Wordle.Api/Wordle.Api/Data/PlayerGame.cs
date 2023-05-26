namespace Wordle.Api.Data
{
    public class PlayerGame
    {
        public int PlayerGameID { get; set; }
        public required Player Player { get; set; }
        public required Word Word { get; set; }
        public DateWord? DateWord { get; set; } = null;
        public int Attempts { get; set; }
        public int DurationInSeconds { get; set; }
        public DateTime GameDate { get; set; }
    }
}
