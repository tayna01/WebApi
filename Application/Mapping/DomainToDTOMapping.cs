using API.Domain.DTOs;
using API.Domain.Model.EmployeeAggregate;
using AutoMapper;

namespace API.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.NameEmployee,
                    m => m.MapFrom(orig => orig.name));
        }
    }
}
