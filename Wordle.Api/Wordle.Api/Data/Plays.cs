using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class Plays
    {
        public int PlaysId { get; set; }
        public int WordId { get; set; }
        public IList<int> PlayerIds { get; set; } = new List<int>();
        public int GrandTotalGames { get; set; }
        public int GrandTotalAttempts { get; set; }
        public int GrandAverageAttempts { get; set; }
        public int GrandTotalTime { get; set; }
        public int GrantAverageTime { get; set; }
    }
}