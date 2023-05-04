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

    public Player(string name)
    {
        Name = name;
        GameCount = 0;
        AverageAttempts = 0;
    }

    public void UpdateAttempts(int attempts) { AverageAttempts = (AverageAttempts + attempts) / ++GameCount; }
}
