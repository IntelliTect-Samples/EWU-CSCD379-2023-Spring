using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Data
{
    public class PlayersDbContext : DbContext
    {
        public PlayersDbContext(DbContextOptions<PlayersDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Player> Players => Set<Player>();
    }
}