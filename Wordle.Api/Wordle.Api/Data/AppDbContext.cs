using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Word> Words => Set<Word>();
        public DbSet<Play> Plays => Set<Play>();
        public DbSet<User> Users => Set<User>(); 
    }
}
