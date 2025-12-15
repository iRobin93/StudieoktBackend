using StudieøktBackend.Model.Entities;

namespace StudieøktBackend.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<Session> AddAsync(Session session);
        Task<List<Session>> GetByDateAsync(DateOnly date);
    }
}
