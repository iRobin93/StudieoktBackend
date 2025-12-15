namespace StudieøktBackend.Model.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Session> Sessions { get; set; } = new List<Session>();

    }
}
