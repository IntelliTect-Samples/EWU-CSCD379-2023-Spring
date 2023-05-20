using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using Wordle.Api.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public static async void SeedPlays(AppDbContext db)
        {
            if (!db.Plays.Any())
            {

                int numPlays = 150;
                int numUsers = db.Users.Count();
                int minUserId = db.Users.Min(u => u.UserId);
                int maxUserId = db.Users.Max(u => u.UserId);
                var words = db.Words.ToList();

                List<Word> wordOptions = new();
                for (int i = 0; i > -10; i--) { 
                    wordOptions.Add(DateToWord(DateTime.Now.AddDays(i), words));
                }


               



                Random r = new(); 
                
                for (int i = 0; i < numPlays; i++) {
                    int userId = r.Next(minUserId, maxUserId);
                    // int word = choose word randomly 
                    int attempts = r.Next(1, 7);
                    int seconds = r.Next(10, 240);
                    db.Plays.Add(new Play()
                    {
                        User = db.Users.Where(u => u.UserId == userId).First(),
                        Word = wordOptions.ElementAt(r.Next(10)),
                        Seconds = seconds,
                        Attempts = attempts
                    }); 
                }
           
                db.SaveChanges();

            }
        }

        public static User StringToUser(string name, AppDbContext db)
        {
            return db.Users.Where((u) => u.Name.Equals(name)).First();
        }

        public static Word StringToWord(string word, AppDbContext db)
        {
            return db.Words.Where((w) => w.Text.Equals(word)).First();
        }

        public static Word DateToWord(DateTime date, List<Word> words)
        {
            DateTime currentDate = date;
            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;

            // Convert to a string
            string dateString = string.Format("{0}/{1}/{2}", year, day, month);
            // Hash the string
            int hashCode;
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(dateString));
                hashCode = BitConverter.ToInt32(hashBytes, 0);

            }
            // Mod by the number of words 
            var count = words.Count(word => word.IsCommon);
            int index = Math.Abs(hashCode % count);
            // Return the word as text
            return (words
                .Where(word => word.IsCommon)
                .Skip(index)
                .First());


        }
    
    }

}
