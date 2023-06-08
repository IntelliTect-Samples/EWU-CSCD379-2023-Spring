using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class SeveralWordsDto
    {
        public IEnumerable<Word>? Words { get; set; }
        public int pageCount { get; set; }
    }
}
