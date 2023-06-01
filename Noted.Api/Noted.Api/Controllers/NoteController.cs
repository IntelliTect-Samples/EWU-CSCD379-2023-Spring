using Microsoft.AspNetCore.Mvc;
using Noted.Api.Services;

namespace Noted.Api.Controllers
{
    [ApiController]
    [Route("Note")]
    public class NoteController : ControllerBase
    {
        private readonly NoteService _NoteService;
        public NoteController(NoteService NoteService)
        {
            _NoteService = NoteService;
        }
    }
}
