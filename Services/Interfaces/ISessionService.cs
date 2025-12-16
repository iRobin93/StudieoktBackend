using StudieøktBackend.Model.DTOs;
using StudieøktBackend.Model.Entities;

namespace StudieøktBackend.Services.Interfaces
{
    public interface ISessionService
    {
        Task<Session> CreateAsync(CreateSessionDTO dto);
        Task<List<GetSessionDTO>> GetByDateAsync(DateOnly date);
        Task<bool> DeleteSessionById(int id);
    }
}
