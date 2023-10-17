// Ignore Spelling: App Sayaratech

using Sayaratech.Entities;
using Sayaratech.Permissions;
using Sayaratech.Services.Contracts;
using Sayaratech.Services.Dtos.Departments;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Sayaratech.Services
{
    public class DepartmentsAppService :
    CrudAppService<
        Department, 
        DepartmentDto, 
        Guid,
        PagedAndSortedResultRequestDto, 
        CreateUpdateDepartmentDto>, 
    IDepartmentsAppService 
    {
        public DepartmentsAppService(IRepository<Department, Guid> repository)
            : base(repository)
        {
            GetPolicyName = SayaratechDepartmentsPermissions.Departments.Default;
            GetListPolicyName = SayaratechDepartmentsPermissions.Departments.Default;
            CreatePolicyName = SayaratechDepartmentsPermissions.Departments.Create;
            UpdatePolicyName = SayaratechDepartmentsPermissions.Departments.Edit;
            DeletePolicyName = SayaratechDepartmentsPermissions.Departments.Delete;
        }
    }
}
