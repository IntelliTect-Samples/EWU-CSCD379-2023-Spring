using Microsoft.AspNetCore.Mvc;
using Noted.Api.Data;
using Noted.Api.Services;

namespace Noted.Api.Controllers
{
    [ApiController]
    [Route("Note")]
    public class NoteController : ControllerBase
    {
        private readonly NoteService _noteService;
        public NoteController(NoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("Get")]
        public IEnumerable<Note> GetNotes()
        {
            return _noteService.GetNotes();
        }

        [HttpPost("Add")]
        public Note AddNote([FromBody] Note note)
        {
            return _noteService.AddNote(note);
        }
    }
}
