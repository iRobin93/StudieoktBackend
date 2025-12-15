using StudieøktBackend.Model.Entities;

namespace StudieøktBackend.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllAsync();
        Task<Subject?> AddAsync(Subject subject);
    }
}
