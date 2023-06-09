using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.Text;
using Wordle.Api.Data;
using Wordle.Api.Identity;
using Wordle.Api.Services;

var MyAllowAllOrigins = "_myAllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
options.AddPolicy(name: MyAllowAllOrigins,
                  policy =>
                  {
                      policy.WithOrigins("*");
                      policy.AllowAnyMethod();
                      policy.AllowAnyHeader();
                  });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "Wordle API", Version = "v1" });
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
}
);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<WordService>();
builder.Services.AddScoped<PlayerService>();

//Identity Services
builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

//JWT Token setup
JwtConfiguration jwtConfiguration = builder.Configuration
    .GetSection("Jwt").Get<JwtConfiguration>() ?? 
    throw new Exception("JWT configuration not specified");

builder.Services.AddSingleton(jwtConfiguration);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfiguration.Issuer,
            ValidAudience = jwtConfiguration.Audience,

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Secret))
        };
    });

//Add Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.RandomAdmin, Policies.RandomAdminPolicy);
    options.AddPolicy("IsGrantPolicy", policy => policy.RequireRole("Grant"));
    options.AddPolicy(Policies.EditWord, Policies.EditWordPolicy);
});

// Actually build the app so we can configure the pipeline next
var app = builder.Build();



// Create and see the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    Seeder.SeedWords(db);
    Seeder.SeedPlayers(db);
    await IdentitySeed.SeedAsync(
        scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>(),
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(),
        scope.ServiceProvider.GetRequiredService<AppDbContext>());
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("UseSwagger", false))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add a redirect for the root URL
var redirectRootUrl = app.Configuration.GetValue<string>("RedirectRootUrl", "");
if (string.IsNullOrEmpty(redirectRootUrl)) redirectRootUrl = "https://purple-rock-0b124a41e.3.azurestaticapps.net/";
var options = new RewriteOptions()
        .AddRedirect("^$", redirectRootUrl, 302);
app.UseRewriter(options);

app.UseHttpsRedirection();

app.UseCors(MyAllowAllOrigins);

// Add Google site verification.
app.MapGet("/google5b827f426094db3f.html", () => "google-site-verification: google5b827f426094db3f.html");

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }