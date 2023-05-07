using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Wordle.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
            .Property(f => f.PlayerId)
            .ValueGeneratedOnAdd();
        }

        public DbSet<Word> Words => Set<Word>();
        public DbSet<Player> Players => Set<Player>();
    }
}
