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
        public string GetRandomWord() 
        {
            var count = _db.Words.Count(word => word.IsCommon);
            var index = new System.Random().Next(count);
            var word = _db.Words.Where(word => word.IsCommon).Skip(index).First();
            return word.Text;
        }
    }
}