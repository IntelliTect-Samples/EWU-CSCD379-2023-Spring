using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Wordle.Api.Data
{
    public class Play
    {
        public Guid PlayId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int WordId { get; set; }
        public Word Word { get; set; } = null!;
        public int Attempts { get; set; }
        public int Seconds { get; set; }

        public static void SeedPlays(AppDbContext db)
        {
            if (!db.Plays.Any())
            {
                


                db.Plays.Add(new Play()
                {
                    User = StringToUser("Mathew Hageland", db),
                    Word = StringToWord("tarps", db),
                    Attempts = 3,
                    Seconds = 21
                });

                db.Plays.Add(new Play()
                {
                    User = StringToUser("Lord Voldemort", db),
                    Word = StringToWord("traps", db),
                    Attempts = 4,
                    Seconds = 43
                });

                db.Plays.Add(new Play()
                {
                    User = StringToUser("Mickey Mouse", db),
                    Word = StringToWord("carps", db),
                    Attempts = 2,
                    Seconds = 53
                });
                db.Plays.Add(new Play()
                {
                    User = StringToUser("Mickey Mouse", db),
                    Word = StringToWord("warps", db),
                    Attempts = 5,
                    Seconds = 33
                });

                db.Plays.Add(new Play()
                {
                    User = StringToUser("Grant Erickson", db),
                    Word = StringToWord("warps", db),
                    Attempts = 2,
                    Seconds = 24
                });

                db.Plays.Add(new Play()
                {
                    User = StringToUser("Grant Erickson", db),
                    Word = StringToWord("warps", db),
                    Attempts = 5,
                    Seconds = 49
                });

                db.Plays.Add(new Play()
                {
                    User = StringToUser("Meg Woodford", db),
                    Word = StringToWord("warps", db),
                    Attempts = 2,
                    Seconds = 22
                });

                db.Plays.Add(new Play()
                {
                    User = StringToUser("Meg Woodford", db),
                    Word = StringToWord("harps", db),
                    Attempts = 3,
                    Seconds = 45
                });
                db.SaveChanges();

            }
        }

        public static User StringToUser(String name, AppDbContext db)
        {
            return db.Users.Where((u) => u.Name.Equals(name)).First();
        }

        public static Word StringToWord(String word, AppDbContext db)
        {
            return db.Words.Where((w) => w.Text.Equals(word)).First();
        }
    }

}
