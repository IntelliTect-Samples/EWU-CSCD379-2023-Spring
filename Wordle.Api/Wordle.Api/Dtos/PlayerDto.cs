namespace Wordle.Api.Dtos;

public class PlayerDto
{
    public string Name { get; set; }
    public double Attempts { get; set; }
    public int TimeInSeconds { get; set; }
}
