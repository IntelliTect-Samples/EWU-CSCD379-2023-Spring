namespace Wordle.Api.Data
{
    public class Play
    {
        private object value;

        public Play(int userId, int wordId, int attempts, int seconds)
        {
            UserId = userId;
            WordId = wordId;
            Attempts = attempts;
            Seconds = seconds; 
        }

        public int UserId { get; set; }
        public int WordId { get; set; }
        public int Attempts { get; set; }
        public int Seconds { get; set; }

    }
}
