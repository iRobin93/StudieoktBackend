using StudieøktBackend.Model.DTOs;
using StudieøktBackend.Model.Entities;
using AutoMapper;

namespace StudieøktBackend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Subject, GetSubjectByDateDTO>();
            CreateMap<Session, GetSessionDTO>();
        }
    }
}
