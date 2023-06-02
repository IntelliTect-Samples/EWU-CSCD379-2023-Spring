using Noted.Api.Data;
using Noted.Api.Dtos;

namespace Noted.Api.Services
{
    public class NoteService
    {
        private readonly AppDbContext _db;

        public NoteService(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Note> GetNotes() 
        {
            return _db.Notes.ToList();
        }

        public void AddNote(NoteDto note)
        {
            if(note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            var newNote = new Note();
            
            if(note.Title == "")
            {
                note.Title = "Note";
            }
            newNote.Title = note.Title;
            newNote.Content = note.Content;
            newNote.deleted = false;
            
            _db.Notes.Add(newNote);
            _db.SaveChanges();   
        }
    }
}
