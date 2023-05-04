namespace Wordle.Api.Data
{

    public class Player
    {
        public required int PlayerId { get; set; }
        public required string Name { get; set; }
        public required int GameCount { get; set; }
        public required double AverageAttempts { get; set; }
        public required double AverageSecondsPerGame { get; set; }

    }
}
