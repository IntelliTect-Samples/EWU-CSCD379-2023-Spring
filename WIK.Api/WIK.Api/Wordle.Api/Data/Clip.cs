
using Microsoft.EntityFrameworkCore.Metadata;
using static System.Net.WebRequestMethods;

namespace Wordle.Api.Data
{

    public class Clip
    {
        public int ClipId { get; set; }
        public required string Url { get; set; }
        public int StartTime { get; set; } = 0;
        public int EndTime { get; set; } = 0;
        public bool Kills { get; set; }
        public int Correct { get; set; } = 0;
        public int Incorrect { get; set; } = 0;
        public int Reports { get; set; } = 0;

        public static void SeeClips(AppDbContext db)
        {
            if (!db.Clips.Any())
            {
                Clip clip1 = new Clip()
                {
                    Url = "https://www.youtube.com/watch?v=_nEOGOC9FPk",
                    StartTime = 13,
                    EndTime = 0,
                    Kills = true
                };
                db.Clips.Add(clip1);
                Clip clip2 = new Clip()
                {
                    Url = "https://www.youtube.com/watch?v=_vbXrlJMh48",
                    StartTime = 3761,
                    EndTime = 3789,
                    Kills = false
                };
                db.Clips.Add(clip2);
                Clip clip3 = new Clip()
                {
                    Url = "https://www.youtube.com/watch?v=GUaMzREbqBI",
                    StartTime = 986,
                    EndTime = 993,
                    Kills = false
                };
                db.Clips.Add(clip3);
                Clip clip4 = new Clip()
                {
                    Url = "https://www.youtube.com/watch?v=tGPk6hiEmHg",
                    StartTime = 94,
                    EndTime = 105,
                    Kills = true
                };
                db.Clips.Add(clip4);



                db.SaveChanges();
            }
        }

    }
}