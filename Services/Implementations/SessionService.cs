using AutoMapper;
using StudieøktBackend.Model.DTOs;
using StudieøktBackend.Model.Entities;
using StudieøktBackend.Repositories;
using StudieøktBackend.Repositories.Interfaces;
using StudieøktBackend.Services.Interfaces;

namespace StudieøktBackend.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMapper _mapper;

        public SessionService(ISessionRepository repository, IMapper mapper)
        {
            _sessionRepository = repository;
            _mapper = mapper;
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

            return await _sessionRepository.AddAsync(session);
        }

        public async Task<List<GetSessionDTO>> GetByDateAsync(DateOnly date)
        {

            var sessions = await _sessionRepository.GetByDateAsync(date);

            return _mapper.Map<List<GetSessionDTO>>(sessions);
        }
        public async Task<bool> DeleteSessionById(int id)
        {
            var session = await _sessionRepository.GetByIdAsync(id);
            if (session == null)
                return false;

            await _sessionRepository.DeleteAsync(session);
            return true;
        }
    }
}
