using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Data
{
    public class Players : DbContext
    {
        public Players(DbContextOptions<Players> options) : base(options) 
        {
            
        }

        public DbSet<Player> Players => Set<Player>();
    }
}