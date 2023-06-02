using Microsoft.AspNetCore.Identity;

namespace Wordle.Api.Data
{
    public class AppUser : IdentityUser
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public static void SeedUsers(AppDbContext db)
        {
            if (!db.Users.Any())
            {
                db.Users.Add(new AppUser() { Name = "Mathew Hageland" });
                db.Users.Add(new AppUser() { Name = "Meg Woodford" });
                db.Users.Add(new AppUser() { Name = "Grant Erickson" });
                db.Users.Add(new AppUser() { Name = "Mickey Mouse" });
                db.Users.Add(new AppUser() { Name = "Lord Voldemort" });
                db.Users.Add(new AppUser() { Name = "Greg Heffley" });
                db.Users.Add(new AppUser() { Name = "Frosty the Snowman"});
                db.Users.Add(new AppUser() { Name = "Aiden Lowe" });
                db.Users.Add(new AppUser() { Name = "Jordan Driscoll" });
                db.Users.Add(new AppUser() { Name = "Abraham Lincoln" });
                db.Users.Add(new AppUser() { Name = "Elvis Presley" });
                db.Users.Add(new AppUser() { Name = "Walter White" });
                db.Users.Add(new AppUser() { Name = "Peter Pan" });
                db.Users.Add(new AppUser() { Name = "Guest" }); 
                db.SaveChanges();

            }

        }
    }
}
