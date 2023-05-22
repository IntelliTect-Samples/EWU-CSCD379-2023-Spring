using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class DateWordDto
    {
        public DateWordDto() { }
        public DateWordDto(DateWord dateWord)
        {
            DateWordId = dateWord.DateWordId;
            TotalAttempts = dateWord.TotalAttempts;
            TotalSeconds = dateWord.TotalSeconds;
            TotalGames = dateWord.TotalGames;
            PlayerParticipants = dateWord.PlayerParticipants;
        }
        public int DateWordId { get; set; }
        public DateTime Date { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; } = null!;
        public int TotalAttempts { get; set; } = 0;
        public int TotalSeconds { get; set; } = 0;
        public int TotalGames { get; set; } = 0;

        public ICollection<Guid> PlayerParticipants { get; } = null!;

        public double? AverageAttempts()
        {
            if (TotalGames == 0)
            {
                return 0.0; 
            }

            return TotalAttempts / TotalGames;
        }

        public double? AverageSecondsPerGame()
        {
            if (TotalGames == 0)
            {
                return 0.0;
            }

            return TotalSeconds / TotalGames;
        }
    }
}
