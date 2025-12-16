using StudieøktBackend.Model.Entities;

namespace StudieøktBackend.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<Session> AddAsync(Session session);
        Task<List<Session>> GetByDateAsync(DateOnly date);
        Task<Session?> GetByIdAsync(int id);
        Task DeleteAsync(Session session);
    }
}
