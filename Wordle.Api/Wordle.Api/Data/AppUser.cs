using Microsoft.AspNetCore.Identity;

namespace Wordle.Api.Data;

public class AppUser: IdentityUser
{
    public required string Name { get; set; }
    public required DateTime BDay { get; set; }
    public int GameCount { get; set; } = 0;
    public bool MasterOfTheUniverse { get; set; } = true;
    public double AverageAttempts { get; set; } = 0;
    public int AverageSecondsPerGame { get; set; } = 0;

}