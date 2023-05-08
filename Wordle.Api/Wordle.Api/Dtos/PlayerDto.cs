namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public required string Name { get; set; }
        public int Attempts { get; set; }
        public int secondsPerGame { get; set; }
    }
}
