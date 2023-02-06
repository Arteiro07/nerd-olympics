using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public string? Description { get; set; }
        public int Value { get; set; }

         
        [ForeignKey("CompetitionId")]
        public virtual Competition Competition { get; set; } = new ();
        public int CompetitionId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; } = new ();
        public int UserId { get; set; }
    }
}