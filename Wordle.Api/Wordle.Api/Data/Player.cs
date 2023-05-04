using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordle.Api.Data;

public class Player
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlayerId { get; set; }
    public string Name { get; set; }
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }

    public Player(string name, int attempts)
    {
        Name = name;
        GameCount = 1;
        AverageAttempts = attempts;
    }

    public void UpdateAttempts(int attempts) {
        GameCount++;
        if (attempts > AverageAttempts) AverageAttempts += attempts / GameCount;
        else if (attempts < AverageAttempts) AverageAttempts -= attempts / GameCount;
    }
}
