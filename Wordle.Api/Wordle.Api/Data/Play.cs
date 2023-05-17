namespace Wordle.Api.Data
{
    public class Play
    {
        public int UserId { get; set; }
        public int WordId { get; set; }
        public int Attempts { get; set; }
        public int Seconds { get; set; }

    }
}
