using System.ComponentModel.DataAnnotations.Schema;

namespace NerdOlympics.Data.Models
{
    public class ScoreLine
    {
        public int RecordId { get; set; }
        public string? Description { get; set; }
        public float Value { get; set; }
        public int CompetitionId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool UserGender { get; set; } = false;
        public int Position { get; set; }
        public int OverallPoints { get; set; }
    }
}
