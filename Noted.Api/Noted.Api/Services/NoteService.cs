using Noted.Api.Data;

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

        public Note AddNote(Note note)
        {
            if(note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            if(note.Title == "")
            {
                note.Title = "Note";
            }
            _db.Notes.Add(note);
            _db.SaveChanges();
            return note;    
        }
    }
}
