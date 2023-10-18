// Ignore Spelling: Sayaratech App

using Sayaratech.Services.Dtos.Departments;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sayaratech.Services.Contracts
{
    public interface IDepartmentsAppService :
    ICrudAppService<DepartmentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDepartmentDto>
    {
    }
}
