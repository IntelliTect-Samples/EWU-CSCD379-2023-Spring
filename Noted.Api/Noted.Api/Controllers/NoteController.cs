using Microsoft.AspNetCore.Mvc;
using Noted.Api.Data;
using Noted.Api.Dtos;
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
        public void AddNote([FromBody] NoteDto note)
        {
            _noteService.AddNote(note);
        }

        [HttpPut("Update")]
        public void UpdateNote([FromBody] NoteDto note)
        {
            _noteService.UpdateNote(note);
        }
    }
}
