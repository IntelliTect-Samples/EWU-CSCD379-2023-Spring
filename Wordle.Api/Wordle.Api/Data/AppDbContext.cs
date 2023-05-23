﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Plays> Plays => Set<Plays>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<DateWord>()
                .HasOne(e => e.Word)
                .WithMany(f => f.DateWords)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
