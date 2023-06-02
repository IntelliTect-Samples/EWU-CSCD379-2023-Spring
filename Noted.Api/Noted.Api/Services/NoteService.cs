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

        public void UpdateNote(NoteDto note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            if (note.Title == "")
            {
                note.Title = "Note";
            }

            var storedNote = _db.Notes.Select(n => n).Where(n => n.Id == note.Id).First();

            if (storedNote == null)
            {
                throw new Exception("Id not found");
            }

            storedNote.Title = note.Title;
            storedNote.Content = note.Content;
            
            _db.SaveChanges();
        }

        public void DeleteNote(NoteDto note)
        {
            if(note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            var storedNote = _db.Notes.Select(n => n).Where(n => n.Id == note.Id).First();

            if (storedNote == null)
            {
                throw new Exception("Id not found");
            }

            storedNote.deleted = true;

            _db.SaveChanges();
        }
    }
}
