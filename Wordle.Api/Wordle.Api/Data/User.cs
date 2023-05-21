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
                db.Users.Add(new User() { Name = "Guest" }); 
                db.SaveChanges();

            }

        }
    }
}
