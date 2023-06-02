using System.ComponentModel.DataAnnotations.Schema;

namespace Noted.Api.Data
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

        public DateTime Created { get; set; }
        public bool deleted { get; set; } 

        public Note()
        {
            this.Created = DateTime.UtcNow;
        }

    }
}
