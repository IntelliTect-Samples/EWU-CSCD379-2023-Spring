using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data;

public class Plays
{
    [Key] public Guid PlayId { get; set; }
    public Guid PlayerId { get; set; }
    public int WordId { get; set; }
    public int DateWordId { get; set; }
    public int Seconds { get; set; }
    public int Attempts { get; set; }
    public DateTime Date { get; set; }

}