// Ignore Spelling: Sayaratech

using Sayaratech.Services.Dtos.Departments;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sayaratech.Services.Contracts
{
    public interface IDepartmentsAppService :
    ICrudAppService< //Defines CRUD methods
        DepartmentDto, //Used to show depts
        Guid, //Primary key of the dept entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateDepartmentDto> //Used to create/update a dept
    {
    }
}
