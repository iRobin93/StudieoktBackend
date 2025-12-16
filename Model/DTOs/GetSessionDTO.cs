namespace StudieøktBackend.Model.DTOs
{
    public class GetSessionDTO
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public DateTime StartedAt { get; set; }
        public int Minutes { get; set; }
        public int SubjectId { get; set; }
    }
}
