// Ignore Spelling: Sayaratech

using AutoMapper;
using Sayaratech.Entities;
using Sayaratech.Services.Dtos.Departments;
using Sayaratech.Services.Dtos.Employees;
using static Sayaratech.Pages.Employees.CreateModalModel;
using static Sayaratech.Pages.Employees.EditModalModel;

namespace Sayaratech.ObjectMapping;

public class SayaratechAutoMapperProfile : Profile
{
    public SayaratechAutoMapperProfile()
    {
        /* Departments */
        CreateMap<Department, DepartmentDto>();
        CreateMap<CreateUpdateDepartmentDto, Department>();
        CreateMap<DepartmentDto, CreateUpdateDepartmentDto>();
        /* Employees */
        CreateMap<Employee, EmployeeDto>();
        CreateMap<CreateUpdateEmployeeDto, Employee>();
        CreateMap<EmployeeDto, CreateUpdateEmployeeDto>();
        CreateMap<Department, DepartmentLookupDto>();
        CreateMap<CreateEmployeeViewModel, CreateUpdateEmployeeDto>();
        CreateMap<EmployeeDto, EditEmployeeViewModel>();
        CreateMap<EditEmployeeViewModel, CreateUpdateEmployeeDto>();
    }
}
