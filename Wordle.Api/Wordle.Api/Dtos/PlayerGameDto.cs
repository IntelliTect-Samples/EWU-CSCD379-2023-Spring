namespace Wordle.Api.Dtos
{
    public class PlayerGameDto
    {
        public DateTime Date { get; set; }
        public double Seconds { get; set; }
        public double Attempts { get; set; }
        public int NumberOfPlays { get; set; }
        public bool HasPlayed { get; set; }
    }
}
