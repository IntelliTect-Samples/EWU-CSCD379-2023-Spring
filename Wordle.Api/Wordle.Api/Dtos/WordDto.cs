namespace Wordle.Api.Dtos
{
    public class WordDto
    {     
        public string? Text { get; set; }
        public bool IsCommon { get; set; }
        public bool IsUsed { get; set; }
    }
}