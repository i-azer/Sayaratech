// Ignore Spelling: Sayaratech

using AutoMapper;
using Sayaratech.Entities;
using Sayaratech.Services.Dtos.Departments;

namespace Sayaratech.ObjectMapping;

public class SayaratechAutoMapperProfile : Profile
{
    public SayaratechAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        CreateMap<Department, DepartmentDto>();
        CreateMap<CreateUpdateDepartmentDto, Department>();
        CreateMap<DepartmentDto, CreateUpdateDepartmentDto>();
    }
}
