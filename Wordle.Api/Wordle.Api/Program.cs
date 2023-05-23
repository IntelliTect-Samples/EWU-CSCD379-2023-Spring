using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Services;

var myAllowAllOrigins = "_myAllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
                         {
                             options.AddPolicy(name: myAllowAllOrigins, policy =>
                                                                        {
                                                                            policy.WithOrigins("*");
                                                                            policy.AllowAnyMethod();
                                                                            policy.AllowAnyHeader();
                                                                            policy.AllowAnyOrigin();
                                                                        });
                         });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
                                            { options.UseSqlServer(connectionString); });
builder.Services.AddScoped<WordService>();
builder.Services.AddScoped<PlayerService>();

// Actually build the app so we can configure the pipeline next
var app = builder.Build();

// Create and see the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    Seeder.SeedWords(db);
    Seeder.SeedPlayers(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("UseSwagger", false))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// TODO: Check if this is something that I need to include...
// Add a redirect for the root URL
// var redirectRootUrl = app.Configuration.GetValue<string>("RedirectRootUrl", "");
// if (string.IsNullOrEmpty(redirectRootUrl)) redirectRootUrl =
// "https://purple-rock-0b124a41e.3.azurestaticapps.net/"; var options = new
// RewriteOptions().AddRedirect("^$", redirectRootUrl); app.UseRewriter(options);

app.UseHttpsRedirection();

app.UseCors(myAllowAllOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}
