using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Competition 
    {
        public int CompetitionId { get; set; }

        public string? Name {get;set;}
    
        public string? Description {get;set;}    
    }
}

