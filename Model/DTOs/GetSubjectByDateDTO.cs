using StudieøktBackend.Model.Entities;

namespace StudieøktBackend.Model.DTOs
{
    public class GetSubjectByDateDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int TotalMinutes { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
