using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Wordle.Api.Data;
using Wordle.Api.Migrations;

namespace Wordle.Api.Services
{
    public class ClipService
    {
        private readonly AppDbContext _db;
        public ClipService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Clip> AddClip(string url, bool kills, int startTime = 0, int endTime = 0)
        {
            Clip? clip = await _db.Clips.FirstOrDefaultAsync(c => c.Url == url);

            if (clip == null)
            {
                clip = new()
                {
                    Url = url,
                    StartTime = startTime,
                    EndTime = endTime,
                    Kills = kills,
                };
                _db.Clips.Add(clip);
            }
            await _db.SaveChangesAsync();
            return clip;
        }
        public async Task<Clip> GetRandomClip()
        {
            var count = await _db.Clips.CountAsync(c => c.Reports < 5);
            var index = new System.Random().Next(count);
            var clip = await _db.Clips.Where(c => c.Reports < 5).Skip(index).FirstAsync();
            return clip;
        }

        public async Task<Clip?> UpdateClipScore(int clipid, bool correct)
        {
            Clip? clip = await _db.Clips.FirstOrDefaultAsync(c => c.ClipId == clipid);
            if (clip != null)
            {
                clip.Correct += correct ? 1 : 0;
                clip.Incorrect += correct ? 0 : 1;
            }
            await _db.SaveChangesAsync();
            return clip;
        }
        public async Task<Clip?> ReportClip(int clipid)
        {
            Clip? clip = await _db.Clips.FirstOrDefaultAsync(c => c.ClipId == clipid);
            if (clip != null)
            {
                clip.Reports++;
            }
            await _db.SaveChangesAsync();
            return clip;
        }
        public async Task<string[]> getTopClips()
        {
            string[] strClip = new string[10];
            for (int i = 0; i < 10; i++)
            {
                strClip[i] = " , , ";
            }
            var clips = await _db.Clips.OrderByDescending(c => c.Correct+c.Incorrect).Take(10).ToArrayAsync();
            int count = 0;
            foreach ( var clip in clips) 
            {
                strClip[count] = $"{clip.Url},{clip.Correct},{clip.Incorrect}";
                count++;
            }

            return strClip;
        }
    }
}