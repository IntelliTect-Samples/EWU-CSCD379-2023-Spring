namespace Wordle.Api.Data;

public class Player
{
    public Guid PlayerId { get; set; }
    public required string PlayerName { get; set; }
    public int GameCount { get; set; }
    public int TotalSecondsPerGame { get; set; }
    public int AverageSecondsPerGame { get; set; }
    public double TotalAttempts { get; set; }
    public double AverageAttempts { get; set; }
}
