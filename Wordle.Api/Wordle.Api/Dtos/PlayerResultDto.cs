using System.ComponentModel.DataAnnotations.Schema;
using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class PlayerResultDto
    {
        public int? PlayerResultId { get; set; }
        public int PlayerId { get; set; }
        public string? PlayerName { get; set; }
        public int Attempts { get; set; }
        public int Duration { get; set; }
        public double Score { get; set; }
        public bool Success { get; set; }
    }
}