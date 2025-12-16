using System.Text.Json.Serialization;

namespace StudieøktBackend.Model.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; set; }
        public int Minutes { get; set; }
        public int SubjectId { get; set; }
        [JsonIgnore]
        public Subject Subject { get; set; }
    }
}
