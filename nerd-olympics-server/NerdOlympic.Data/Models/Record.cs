using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NerdOlympics.Data.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public string? Description { get; set; }
        public int Value { get; set; }

        [JsonIgnore]
        [ForeignKey("CompetitionId")]
        public virtual Competition Competition { get; set; } = new ();
        public int CompetitionId { get; set; }

        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = new ();
        public int UserId { get; set; }
    }
}