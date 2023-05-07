
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Wordle.Api.Data
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }

        [SetsRequiredMembers]
        public Player(string name, int gameCount, double averageAttempts)
        {
            Name = name;
            GameCount = gameCount;
            AverageAttempts = averageAttempts;
        }
    }
}