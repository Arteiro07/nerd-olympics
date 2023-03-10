using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NerdOlympics.Data.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public string? Description { get; set; }        
        public string Value { get; set; } = string.Empty;

        [ForeignKey("Competition")]
        public int CompetitionId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}