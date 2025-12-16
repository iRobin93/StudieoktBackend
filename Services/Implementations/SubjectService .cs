using AutoMapper;
using StudieøktBackend.Model.DTOs;
using StudieøktBackend.Model.Entities;
using StudieøktBackend.Repositories.Interfaces;
using StudieøktBackend.Services.Interfaces;


namespace StudieøktBackend.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        private readonly IMapper _mapper;
        public SubjectService(ISubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<GetSubjectByDateDTO>> GetSubjectsByDateAsync(DateOnly date)
        {
            
            var subjects = await _repository.GetByDateAsync(date);
            var subjectDtoList = _mapper.Map<List<GetSubjectByDateDTO>>(subjects);
            foreach (var subjectDto in subjectDtoList)
            {
                int totalMinutes = 0;
                foreach (var session in subjectDto.Sessions)
                {
                    
                    totalMinutes += session.Minutes;
                }
                subjectDto.TotalMinutes = totalMinutes;
                
            }
            return subjectDtoList;
        }

        public async Task<Subject?> CreateSubjectAsync(Subject subject)
        {
            if (string.IsNullOrWhiteSpace(subject.Name))
                return null;

            return await _repository.AddAsync(subject);
        }
    }
}
