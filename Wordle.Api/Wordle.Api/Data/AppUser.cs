using Microsoft.AspNetCore.Identity;

namespace Wordle.Api.Data;

public class AppUser: IdentityUser
{
    public required string Name { get; set; }
    public required DateTime BDay { get; set; }
    public int GameCount { get; set; }
    public bool MasterOfTheUniverse { get; set; }
    public double AverageAttempts { get; set; }
    public int AverageSecondsPerGame { get; set; }

}