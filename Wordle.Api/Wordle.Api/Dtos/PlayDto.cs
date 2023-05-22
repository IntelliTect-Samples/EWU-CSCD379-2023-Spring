using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class PlayDto
    {
        public bool HasPlayed { get; set; }
        public DateTime? GameDate { get; set; }
        public int? NumberOfPlays { get; set; }
        public int? AvgScore { get; set; }
        public int? AvgTime { get; set; }   
    }
}
