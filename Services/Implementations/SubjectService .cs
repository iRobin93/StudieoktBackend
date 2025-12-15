using StudieøktBackend.Model.Entities;
using StudieøktBackend.Repositories.Interfaces;
using StudieøktBackend.Services.Interfaces;


namespace StudieøktBackend.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;

        public SubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Subject?> CreateSubjectAsync(Subject subject)
        {
            if (string.IsNullOrWhiteSpace(subject.Name))
                return null;

            return await _repository.AddAsync(subject);
        }
    }
}
