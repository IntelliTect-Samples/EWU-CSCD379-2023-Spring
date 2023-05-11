using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class WordController : ControllerBase
{
    private readonly WordService _wordService;

    public WordController(WordService wordService)
    {
        _wordService = wordService;
    }

    [HttpGet]
    public async Task<string> Get()
    {
        return await _wordService.GetRandomWord();
    }

    // NOTE: Disabled because unused. Respective service method and UI components are also disabled.
    //       (Disabled group set => Set 1)
    // [HttpGet("GetManyWords")]
    // public async Task<IEnumerable<Word>> GetManyWords(int? count)
    // {
    //     return await _wordService.GetSeveralWords(count);
    // }
    
    // NOTE: Disabled because unused. Respective service method and UI components are also disabled.
    //       (Disabled group set => Set 1)
    // [HttpPost]
    // public async Task<Word> AddWord(string newWord, bool isCommon)
    // {
    //     return await _wordService.AddWord(newWord, isCommon);
    // }

    // NOTE: Disabled because unused. Respective service method and UI components are also disabled.
    //       (Disabled group set => Set 1)
    // [HttpPost("AddWordFromBody")]
    // public async Task<Word> AddWordFromBody([FromBody] WordDto word)
    // {
    //     return await _wordService.AddWord(word.Text, word.IsCommon);
    // }

    [HttpGet("GetWordList")]
    public async Task<List<string>> GetWordList()
    {
        return await _wordService.GetWordList();
    }
}
