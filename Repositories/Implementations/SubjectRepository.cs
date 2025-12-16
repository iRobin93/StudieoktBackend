using global::StudieøktBackend.Data;
using global::StudieøktBackend.Model.Entities;
using global::StudieøktBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StudieøktBackend.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            return await _context.Subjects.ToListAsync();
        }
        public async Task<List<Subject>> GetByDateAsync(DateOnly date)
        {
            return await _context.Subjects
                .Include(s => s.Sessions
                    .Where(sess => DateOnly.FromDateTime(sess.StartedAt) == date))
                .ToListAsync();
        }

        public async Task<Subject?> GetByIdAsync(int id)
        {
            return await _context.Subjects
                .Include(s => s.Sessions)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task DeleteAsync(Subject subject)
        {
            _context.Subjects.Remove(subject);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Subject?> AddAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }
    }
}