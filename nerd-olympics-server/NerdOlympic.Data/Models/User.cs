using System.Text.Json.Serialization;

namespace NerdOlympics.Data.Models
{
    public class User
    {
        public int UserId {get;set;}
        public string? Name {get;set;}
        public string? Email {get;set;}
        public string? AvatarId {get;set;}
        [JsonIgnore]
        public bool IsAdmin { get;set;}
        [JsonIgnore]
        public string? Password {get;set;}
    }
}
