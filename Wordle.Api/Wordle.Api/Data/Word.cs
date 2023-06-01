using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class Word
    {
        public int WordId { get; set; }
        public required string Text { get; set; }
        public bool IsCommon { get; set; }

        public bool IsUsed { get; set; }
        public IList<DateWord> DateWords { get; set; } = new List<DateWord>();

    }
}
