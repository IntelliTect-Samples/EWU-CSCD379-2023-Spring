using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Data
{
    public class Plays
    {
        public int PlaysId { get; set; }
        public int PlayerId { get; set; }
        public required Player Player { get; set; }
        public int WordId { get; set; }
        public required Word Word { get; set; }
        public int? DateWordId { get; set; }
        public DateWord? DateWord { get; set; }

        public int Attempts { get; set; }
        public int TimeInSeconds { get; set; }
        public DateTime Date { get; set; }
        public bool WasGameWon { get; set; }
    }
}