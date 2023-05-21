﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wordle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayController : ControllerBase
    {
        private readonly PlayService _PlayService;
        public PlayController(PlayService playService)
        {
            _PlayService = playService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Play>>> GetLastTenDates(DateTime GameDate)
        {
            return (await _PlayService.GetLastTenDates());
        }

    }
}