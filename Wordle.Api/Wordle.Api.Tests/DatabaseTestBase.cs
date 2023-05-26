using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wordle.Api.Data;

namespace Wordle.Api.Tests;

public abstract class DatabaseTestBase
{
    private SqliteConnection SqliteConnection { get; set; } = null!;
    protected DbContextOptions<AppDbContext> Options { get; private set; } = null!;

    private static ILoggerFactory GetLoggerFactory()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(builder =>
        {
            builder.AddConsole();
        });
        return serviceCollection.BuildServiceProvider().
            GetService<ILoggerFactory>()!;
    }

    [TestInitialize]
    public void InitializeDb()
    {
        SqliteConnection = new SqliteConnection("DataSource=:memory:");
        SqliteConnection.Open();

        Options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(SqliteConnection)
            .UseLoggerFactory(GetLoggerFactory())
            .EnableSensitiveDataLogging()
            .Options;

        using var context = new AppDbContext(Options);
        context.Database.EnsureCreated();
    }

    [TestCleanup]
    public void CloseDbConnection()
    {
        SqliteConnection.Close();
    }
}

