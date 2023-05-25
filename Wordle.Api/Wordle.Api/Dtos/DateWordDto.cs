using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class DateWordDto
    {
        public DateWordDto(DateWord dateWord)
        {
            Word = dateWord.Word.Text;
            Date = dateWord.Date;
        }

        public string Word { get; set; }
        public DateTime Date { get; set; }
    }
}
