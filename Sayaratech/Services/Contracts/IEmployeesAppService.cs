// Ignore Spelling: Sayaratech

using Sayaratech.Services.Dtos.Employees;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sayaratech.Services.Contracts
{
    public interface IEmployeesAppService :
    ICrudAppService<EmployeeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEmployeeDto>
    {
        Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync();
    }
}
