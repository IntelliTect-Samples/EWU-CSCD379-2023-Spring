namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public required string Name { get; set; }
        public int TotalAttempts { get; set; }
        public int GameCount { get; set; }
        public int? TotalSeconds { get; set; }
    }
}

