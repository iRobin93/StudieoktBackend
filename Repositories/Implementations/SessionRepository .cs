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
            var start = date.ToDateTime(TimeOnly.MinValue);
            var end = date.ToDateTime(TimeOnly.MaxValue);

            return await _context.Sessions
                .Include(s => s.Subject)
                .Where(s => s.StartedAt >= start && s.StartedAt <= end)
                .OrderBy(s => s.StartedAt)
                .ToListAsync();
        }

        public async Task<Session?> GetByIdAsync(int id)
        {
            return await _context.Sessions.FindAsync(id);
        }

        public async Task DeleteAsync(Session session)
        {
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
        }

    }

}
