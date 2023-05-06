namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public required string Name { get; set; }
        public int NumAttempts { get; set; }
    }
}
