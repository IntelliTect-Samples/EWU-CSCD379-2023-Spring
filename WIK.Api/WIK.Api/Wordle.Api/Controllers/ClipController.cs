using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Migrations;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClipController : ControllerBase
    {
        private readonly ClipService _clipService;
        public ClipController(ClipService clipService)
        {

            _clipService = clipService;
        }
        [HttpGet]
        public async Task<string> Get()
        {
            Clip clip = await _clipService.GetRandomClip();
            return $"{clip.ClipId},{clip.Url},{clip.StartTime},{clip.EndTime},{clip.Kills}";
        }
        [HttpGet("TopClips")]
        public async Task<string[]> GetTopClips() 
        {
            return await _clipService.getTopClips();
        }

        [HttpPost]
        public async Task<Clip> AddClip(string url, bool kills, int startTime = 0, int endTime = 0)
        {
            return await _clipService.AddClip(url, kills, startTime, endTime);
        }
        [HttpPost("UpdateClip")]
        public async Task<Clip?> UpdateWord(int clipid, bool correct)
        {
            return await _clipService.UpdateClipScore(clipid, correct);
        }
        [HttpPost("ReportClip")]
        public async Task<Clip?> ReportCLip(int clipid) 
        { 
            return await _clipService.ReportClip(clipid);
        }
    }
}