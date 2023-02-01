using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Competition 
    {
        public int CompetitionId { get; set; }
        public string? Name {get;set;}    
        public string? Description {get;set;}
        public DateTime? CreatedDate { get; set; }

        [ForeignKey("Users")]
        public int CreationUserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}

