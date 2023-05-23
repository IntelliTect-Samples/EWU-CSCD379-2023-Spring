using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class Plays
    {
        //saved data
        public int PlaysId { get; set; }
        public int WordId { get; set; }
        public DateTime Date { get; set; }
        public IList<int> PlayerIds { get; set; } = new List<int>();

        //calculations
        public int GrandTotalGames { get; set; }
        public int GrandTotalAttempts { get; set; }
        public int GrandAverageAttempts { get; set; }
        public int GrandTotalTime { get; set; }
        public int GrantAverageTime { get; set; }
    }
}