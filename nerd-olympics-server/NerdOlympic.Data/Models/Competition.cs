using NerdOlympics.Data.Enum.Competitions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NerdOlympics.Data.Models
{
    public class Competition 
    {
        public int CompetitionId { get; set; }
        public string? Name {get;set;}    
        public string? Description {get;set;}
        public DateTime? CreatedDate { get; set; }
        public ClassificationType ClassificationType { get; set; }
        public CompetitionType MeasurementType { get; set; }
        
        [Display(Name = "User")]
        public int UserId { get; set; }
    }
}

