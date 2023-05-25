
namespace Wordle.Api.Data
{
    public class DateWord
    {
        public int DateWordId { get; set; }
        public DateTime Date { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; } = null!;
        public int Plays { get; set; } = 0;
        public double AverageAttempts { get; set; } = 0;
        public double AverageSeconds { get; set; } = 0;

    }
}