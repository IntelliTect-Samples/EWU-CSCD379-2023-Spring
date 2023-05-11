using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services;

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
        var index = new Random().Next(count);
        var word = await _db.Words.Where(word => word.IsCommon).Skip(index).FirstAsync();
        return word.Text;
    }

    // NOTE: Disabled because unused. Respective controller method and UI components are also
    //       disabled. (Disabled group set => Set 1)
    // public async Task<IEnumerable<Word>> GetSeveralWords(int? count)
    // {
    //     count ??= 10;
    //     var totalCount = await _db.Words.CountAsync(word => word.IsCommon);
    //     totalCount -= count.Value;
    //     int index = new Random().Next(totalCount);
    //     var words = await _db.Words.Where(word => word.IsCommon)
    //                     .Skip(index)
    //                     .Take(count.Value)
    //                     .OrderByDescending(w => w.Text)
    //                     .ToListAsync();
    //     return words;
    // }

    // NOTE: Disabled because unused. Respective controller method and UI components are also
    //       disabled. (Disabled group set => Set 1)
    // public async Task<Word> AddWord(string? newWord, bool isCommon)
    // {
    //     if (newWord is null || newWord.Length != 5)
    //     {
    //         throw new ArgumentException("Word must be 5 characters long");
    //     }
    //     var word = await _db.Words.FirstOrDefaultAsync(w => w.Text == newWord);
    //     if (word != null)
    //     {
    //         word.IsCommon = isCommon;
    //     }
    //     else
    //     {
    //         word = new() { Text = newWord, IsCommon = isCommon };
    //         _db.Words.Add(word);
    //     }
    //     await _db.SaveChangesAsync();
    //     return word;
    // }

    public async Task<List<string>> GetWordList()
    {
        return await _db.Words.Select(word => word.Text).ToListAsync();
    }
}
