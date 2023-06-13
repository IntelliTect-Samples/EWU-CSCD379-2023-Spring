
using Microsoft.EntityFrameworkCore.Metadata;

namespace Wordle.Api.Data
{

    public class Clip
    {
        public int ClipId { get; set; }
        public required string Url { get; set; }
        public int StartTime { get; set; } = 0;
        public int EndTime { get; set; } = 0;
        public bool Kills { get; set; }
        public int Correct { get; set; } = 0;
        public int Incorrect { get; set; } = 0;
        public int Reports { get; set; } = 0;

    }
}