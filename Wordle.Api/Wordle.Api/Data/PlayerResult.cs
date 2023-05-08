using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Wordle.Api.Dtos;

namespace Wordle.Api.Data
{
    public class PlayerResult
    {
        public int PlayerResultId { get; set; }
        public int PlayerId { get; set; }
        [ForeignKey(nameof(PlayerId))]
        public Player? Player { get; set; }
        public int Attempts { get; set; }
        public int Duration { get; set; }
        public double Score { get; set; }
        public bool Success { get; set; }

        public void CalculateScore()
        {
            if (!Success)
            {
                Score = 0;
                return;
            }

            double score = 100 - ((Attempts - 1) * 5);
            score -= Duration / 10000;
            Score = score;
        }
    }
}
