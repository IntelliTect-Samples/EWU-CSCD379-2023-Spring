using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System.Numerics;
using System.Reflection.Metadata;

namespace Wordle.Api.Data
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Word> Words => Set<Word>();
        public DbSet<Player> Players => Set<Player>();

        public DbSet<DateWord> DateWords => Set<DateWord>();
        public DbSet<DailyCompletions> DailyCompletions => Set<DailyCompletions>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<DateWord>()
                .HasOne(e => e.Word)
                .WithMany(f => f.DateWords)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
                .Entity<DateWord>()
                .HasIndex(e => e.Date)
                .IsUnique();
            modelBuilder
                .Entity<DailyCompletions>()
                .HasKey(m => new { m.DateWordId, m.PlayerName});

        }
    }
}