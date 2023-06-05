using Microsoft.AspNetCore.Identity;

namespace Wordle.Api.Data;

public class AppUser : IdentityUser
{
    public required string Name { get; set; }
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }
    public int AverageSecondsPerGame { get; set; }
    public Boolean MasterOfTheUniverse { get; set; } = false;
    public required DateTime Birthday { get; set; }
}