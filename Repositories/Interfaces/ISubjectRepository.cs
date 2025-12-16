using StudieøktBackend.Model.Entities;

namespace StudieøktBackend.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllAsync();
        Task<Subject?> AddAsync(Subject subject);
        Task<List<Subject>> GetByDateAsync(DateOnly date);
        Task<Subject?> GetByIdAsync(int id);
        Task DeleteAsync(Subject subject);
        Task<bool> SaveChangesAsync();
    }
}
