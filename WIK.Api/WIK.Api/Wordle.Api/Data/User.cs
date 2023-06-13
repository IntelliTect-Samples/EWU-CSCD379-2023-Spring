
namespace Wordle.Api.Data
{

    public class User
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public int Wins { get; set; } = 0;
        public int Loses { get; set; } = 0;

        public static void SeedUsers(AppDbContext db)
        {
            if (!db.Users.Any())
            {
                User admin = new User() 
                { 
                    Username = "admin", 
                    Password = "admin",
                    Wins = 0,
                    Loses = 0,
                };
                db.Users.Add(admin);
                User guest = new User() 
                {
                    Username= "guest",
                    Password= "password",
                    Wins = 0,
                    Loses = 0
                };
                db.Users.Add(guest);
                db.SaveChanges();
            }
        }

    }

    
}