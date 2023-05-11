namespace Wordle.Api.Data;

public class Player
{
    public Guid PlayerId { get; set; }
    public required string Name { get; set; }
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }
    public int AverageSecondsPerGame { get; set; }

}