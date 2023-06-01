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
    }
}
