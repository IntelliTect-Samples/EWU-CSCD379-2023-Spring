namespace Wordle.Api.Dtos
{
    public class PlayDto
    {
        public required string Name { get; set; }
        public int Attempts { get; set; }
        public int Seconds { get; set; }
        public required string Word { get; set; }

    }
}
