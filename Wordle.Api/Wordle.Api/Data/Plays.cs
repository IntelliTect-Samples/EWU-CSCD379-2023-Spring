using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Data
{
    public class Plays
    {
        public int PlaysId { get; set; }
        public int PlayerId { get; set; }
        public required Player Player { get; set; }
        public int WordId { get; set; }
        public required Word Word { get; set; }
        public int? DateWordId { get; set; }
        public DateWord? DateWord { get; set; }

        public int Attempts { get; set; }
        public int TimeInSeconds { get; set; }
        public DateTime Date { get; set; }
        public bool WasGameWon { get; set; }

        public static async void SeedPlays(AppDbContext db)
        {
        if (!db.Plays.Any())
        {
            var playslines = System.IO.File.ReadAllLines("Content/Plays.csv");
            foreach (var line in playslines)
            {
                var parts = line.Split(',');

        var player = await db.Players.FirstOrDefaultAsync(n => n.PlayerId == int.Parse(parts[0]));
        var word = await db.Words.FirstOrDefaultAsync(f => f.WordId == int.Parse(parts[1]));
        var dateWord = await db.DateWords.FirstOrDefaultAsync(f => f.DateWordId == int.Parse(parts[2]));

        var play = new Plays()
        {
            PlayerId = int.Parse(parts[0]),
            Player = player,
            WordId = int.Parse(parts[1]),
            Word = word,
            DateWordId = int.Parse(parts[2]),
            Attempts = int.Parse(parts[3]),
            TimeInSeconds = int.Parse(parts[4]),
            Date = DateTime.Parse(parts[5]),
            WasGameWon = bool.Parse(parts[6])
        };
        db.Plays.Add(play);
            }
    db.SaveChanges();
        }
    }
    }
}