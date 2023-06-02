﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Metadata;

namespace Wordle.Api.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
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
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<DateWord>()
                .HasOne(e => e.Word)
                .WithMany(f => f.DateWords)
                .OnDelete(DeleteBehavior.ClientCascade);

            /* Add?S
             modelBuilder
                .Entity<DateWord>()
                .HasIndex(f => f.Date)
                .IsUnique();
             */
        }
    }
}
