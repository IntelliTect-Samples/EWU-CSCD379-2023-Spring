using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public required string Name { get; set; }
        public int TotalAttempts { get; set; }
        public int GameCount { get; set; }
        public int? TotalSeconds { get; set; }
        public double AverageAttempts
        {
            get
            {
                if (GameCount == 0)
                {
                    return 0;
                }
                else
                {
                    return (double)TotalAttempts / GameCount;
                }
            }
        }

        public double AverageSecondsPerGame
        {
            get
            {
                if (TotalSeconds == null || GameCount == 0)
                {
                    TotalSeconds = 0;
                    return 0;
                }
                return (double) TotalSeconds / GameCount;
            }
            
        }
        
    }
}
