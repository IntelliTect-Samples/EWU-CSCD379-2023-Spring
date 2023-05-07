
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }

        public Player(int playerId, string name, int gameCount, double averageAttempts)
        {
            PlayerId = playerId;
            Name = name;
            GameCount = gameCount;
            AverageAttempts = averageAttempts;
        }
    }
}