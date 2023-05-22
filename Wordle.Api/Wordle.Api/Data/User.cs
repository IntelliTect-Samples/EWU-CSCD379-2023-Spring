namespace Wordle.Api.Data
{
    public class User
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public static void SeedUsers(AppDbContext db)
        {
            if (!db.Users.Any())
            {
                db.Users.Add(new User() { Name = "Mathew Hageland" });
                db.Users.Add(new User() { Name = "Meg Woodford" });
                db.Users.Add(new User() { Name = "Grant Erickson" });
                db.Users.Add(new User() { Name = "Mickey Mouse" });
                db.Users.Add(new User() { Name = "Lord Voldemort" });
                db.Users.Add(new User() { Name = "Greg Heffley" });
                db.Users.Add(new User() { Name = "Frosty the Snowman"});
                db.Users.Add(new User() { Name = "Aiden Lowe" });
                db.Users.Add(new User() { Name = "Jordan Driscoll" });
                db.Users.Add(new User() { Name = "Abraham Lincoln" });
                db.Users.Add(new User() { Name = "Elvis Presley" });
                db.Users.Add(new User() { Name = "Walter White" });
                db.Users.Add(new User() { Name = "Peter Pan" });
                db.Users.Add(new User() { Name = "Guest" }); 
                db.SaveChanges();

            }

        }
    }
}
