namespace Wordle.Api.Data;

public class PlayedGame
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Word { get; set; }
    public int PlayerId { get; set; }
    public int Attempts { get; set; }

    public PlayedGame(DateTime date, string word, int playerId, int attempts)
    {
        Date = date;
        Word = word;
        PlayerId = playerId;
        Attempts = attempts;
    }
}
