using StudieøktBackend.Model.DTOs;
using StudieøktBackend.Model.Entities;
using StudieøktBackend.Repositories.Interfaces;
using StudieøktBackend.Services.Interfaces;

namespace StudieøktBackend.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _repository;

        public SessionService(ISessionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Session> CreateAsync(CreateSessionDTO dto)
        {
            if (dto.Minutes <= 0)
                throw new ArgumentException("Minutes must be greater than 0");

            var session = new Session
            {
                SubjectId = dto.SubjectId,
                Minutes = dto.Minutes,
                StartedAt = dto.StartedAt
            };

            return await _repository.AddAsync(session);
        }

        public async Task<List<Session>> GetByDateAsync(DateOnly date)
        {
            return await _repository.GetByDateAsync(date);
        }
    }
}
