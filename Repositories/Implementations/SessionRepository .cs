using StudieøktBackend.Data;
using StudieøktBackend.Model.Entities;
using StudieøktBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StudieøktBackend.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;

        public SessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Session> AddAsync(Session session)
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task<List<Session>> GetByDateAsync(DateOnly date)
        {
            return await _context.Sessions
                .Include(s => s.Subject)
                .Where(s => DateOnly.FromDateTime(s.StartedAt) == date)
                .ToListAsync();
        }
    }

}
