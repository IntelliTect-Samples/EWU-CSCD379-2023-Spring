using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class WordService
    {
        private readonly AppDbContext _db;
        
        public WordService(AppDbContext db)
        {
            _db = db;
        }
        
        public async Task<string> GetRandomWord()
        {
            var count = await _db.Words.CountAsync(word => word.IsCommon);
            var index = new System.Random().Next(count);
            var word = await _db.Words.Where(word => word.IsCommon).Skip(index).FirstAsync();
            return word.Text;
        }
    }
}
