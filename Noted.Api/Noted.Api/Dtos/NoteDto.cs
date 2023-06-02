namespace Noted.Api.Dtos
{
    public class NoteDto
    {
        public Guid? Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public bool deleted { get; set; }
    }
}
