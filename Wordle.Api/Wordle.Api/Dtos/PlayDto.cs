using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class PlayDto
    {
        public PlayDto() { }
        public PlayDto(Play play)
        {
            HasPlayed = play.HasPlayed;
            WordId = play.WordId;
            GameDate = play.GameDate;
            NumberOfPlays = play.NumberOfPlays;
            AvgScore = play.AvgScore;
            AvgTime = play.AvgTime;
        }
        public Boolean? HasPlayed { get; set; }
        public Guid? PlayerId { get; set; }
        public int? WordId { get; set; }
        public DateTime GameDate { get; set; }
        public int? NumberOfPlays { get; set; }
        public int? AvgScore { get; set; }
        public int? AvgTime { get; set; }   
    }
}
