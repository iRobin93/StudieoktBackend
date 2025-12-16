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

            CreateMap<Session, GetSessionDTO>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name));
        }
    }
}
