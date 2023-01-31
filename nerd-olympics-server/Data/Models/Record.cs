using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public string? Description { get; set; }
         
        [ForeignKey("Competitions")]
        public int CompetitionsId { get; set; }
         
        [ForeignKey("Users")]
        public int UsersId { get; set; }
    }
}