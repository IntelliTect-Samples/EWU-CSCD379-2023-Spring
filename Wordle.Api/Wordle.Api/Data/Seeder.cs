namespace Wordle.Api.Data
{
    public static class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            SeedPlayers(context);
            SeedWords(context);
        }

        public static void SeedWords(AppDbContext db)
        {
            if (!db.Words.Any())
            {
                var wordLines = System.IO.File.ReadAllLines("Content/Words.csv");
                foreach (var line in wordLines)
                {
                    var parts = line.Split(',');
                    var word = new Word()
                    {
                        Text = parts[0],
                        IsCommon = bool.Parse(parts[1])
                    };
                    db.Words.Add(word);
                }
                db.SaveChanges();
            }
        }

        public static void SeedPlayers(AppDbContext db)
        {
            if (!db.Players.Any())
            {
                db.Players.Add(new Player { Name = "Sam", AverageAttempts = 4.5, AverageSecondsPerGame = 62, GameCount = 25, PlayerId = Guid.NewGuid() });
                db.Players.Add(new Player { Name = "James", AverageAttempts = 4.8, AverageSecondsPerGame = 195, GameCount = 42, PlayerId = Guid.NewGuid() });
                db.Players.Add(new Player { Name = "Kelly", AverageAttempts = 3.5, AverageSecondsPerGame = 30, GameCount = 55, PlayerId = Guid.NewGuid() });
                db.Players.Add(new Player { Name = "Susan", AverageAttempts = 2.7, AverageSecondsPerGame = 70, GameCount = 23, PlayerId = Guid.NewGuid() });
                db.SaveChanges();
            }
        }

        public static void SeedDateWords(AppDbContext db)
        {
            if (db.DateWords.Count() < 10)
            {
                db.Players.Add(new Player { Name = "Sam", AverageAttempts = 4.5, AverageSecondsPerGame = 62, GameCount = 25, PlayerId = Guid.NewGuid() });
                db.DateWords.Add(new DateWord { Date = DateTime.Now.AddDays(-1), WordId = 46, Word = new Word { IsUsed = true, Text = "about" } });
                db.DateWords.Add(new DateWord { Date = DateTime.Now.AddDays(-2), WordId = 46, Word = new Word { IsUsed = true, Text = "above" } });
                db.DateWords.Add(new DateWord { Date = DateTime.Now.AddDays(-3), WordId = 46, Word = new Word { IsUsed = true, Text = "abuse" } });
                db.DateWords.Add(new DateWord { Date = DateTime.Now.AddDays(-4), WordId = 46, Word = new Word { IsUsed = true, Text = "abuts" } });
                db.DateWords.Add(new DateWord { Date = DateTime.Now.AddDays(-5), WordId = 46, Word = new Word { IsUsed = true, Text = "abyss" } });
                db.DateWords.Add(new DateWord { Date = DateTime.Now.AddDays(-6), WordId = 46, Word = new Word { IsUsed = true, Text = "acids" } });
                db.DateWords.Add(new DateWord { Date = DateTime.Now.AddDays(-7), WordId = 46, Word = new Word { IsUsed = true, Text = "acing" } });
                db.DateWords.Add(new DateWord { Date = DateTime.Now.AddDays(-8), WordId = 46, Word = new Word { IsUsed = true, Text = "acorn" } });
                db.DateWords.Add(new DateWord { Date = DateTime.Now.AddDays(-9), WordId = 46, Word = new Word { IsUsed = true, Text = "acrid" } });
                db.DateWords.Add(new DateWord { Date = DateTime.Now.AddDays(-10), WordId = 46, Word = new Word { IsUsed = true, Text = "adapt" } });
                db.SaveChanges();
            }
        }
    }
}
