using Wordle.API.Data;

namespace Wordle.API.Services
    {
    public class WordService
    {
        private readonly AppDbcontext _db;
        public WordService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<string> GetRandomWord()
        {
        var count = await _db.Words.CountAsync(word => word.isCommon );
        var index = new System.Random().Next(count);
        var word = await _db.Words.Where(word => word.isCommon).Skip(index).FirstAsync();
        return word.Text;
        }
    }
}
