using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class DailyGameResultDto
    {
        
        public Guid PlayerId { get; set; }
        public bool WasGameWon { get; set; }
        public int Attempts { get; set; }
        public int DurationInSeconds { get; set; }
        public DateWord dateWord { get; set; }
    }
}
