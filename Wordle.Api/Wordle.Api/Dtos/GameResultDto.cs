namespace Wordle.Api.Dtos
{
    public class GameResultDto
    {
        public required string Name { get; set; }
        public int Attempts { get; set; }
        public int SecondsInGame { get; set; }
        public int GameCount { get; set; }
    }
}
