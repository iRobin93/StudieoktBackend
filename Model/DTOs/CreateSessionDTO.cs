namespace StudieøktBackend.Model.DTOs
{
    public class CreateSessionDTO
    {
        public int SubjectId { get; set; }
        public int Minutes { get; set; }
        public DateTime StartedAt { get; set; }
    }
}
