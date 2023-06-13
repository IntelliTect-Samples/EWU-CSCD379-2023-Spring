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

        public DbSet<User> Users => Set<User>();
        public DbSet<Clip> Clips => Set<Clip>();
    }
}