using Microsoft.AspNetCore.Identity;

namespace Wordle.Api
{
    public class AppUser : IdentityUser
    {
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
        public int AverageSecondsPerGame { get; set; }
        public DateTime Birthday { get; set; }
    }
}