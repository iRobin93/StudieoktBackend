using StudieøktBackend.Model.DTOs;
using StudieøktBackend.Model.Entities;

namespace StudieøktBackend.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllSubjectsAsync();
        Task<Subject?> CreateSubjectAsync(Subject subject);
        Task<List<GetSubjectByDateDTO>> GetSubjectsByDateAsync(DateOnly date);
    }
}
