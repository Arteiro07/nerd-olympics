using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Models
{
    public class Competition 
    {
        public int CompetitionId { get; set; }
        public string? Name {get;set;}    
        public string? Description {get;set;}
        public DateTime? CreatedDate { get; set; }
        
        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User Owner { get; set; } = new();
        public int UserId { get; set; }
    }
}

