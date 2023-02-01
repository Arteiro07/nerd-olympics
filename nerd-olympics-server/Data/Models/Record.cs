using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public string? Description { get; set; }
         
        [ForeignKey("Competitions")]
        public int CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }
         
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User User { get; set; }  
    }
}