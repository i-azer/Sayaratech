// Ignore Spelling: Sayaratech App

using Microsoft.AspNetCore.Authorization;
using Sayaratech.Entities;
using Sayaratech.Permissions;
using Sayaratech.Services.Contracts;
using Sayaratech.Services.Dtos.Employees;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Sayaratech.Services
{
    [Authorize(SayaratechEmployeesPermissions.Employees.Default)]
    public class EmployeesAppService :
    CrudAppService<
        Employee,
        EmployeeDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateEmployeeDto>,
    IEmployeesAppService
    {
        private readonly IRepository<Department, Guid> _departmentRepository;
        public EmployeesAppService(IRepository<Employee, Guid> repository, IRepository<Department, Guid> departmentRepository)
            : base(repository)
        {
            _departmentRepository = departmentRepository;
            GetPolicyName = SayaratechEmployeesPermissions.Employees.Default;
            GetListPolicyName = SayaratechEmployeesPermissions.Employees.Default;
            CreatePolicyName = SayaratechEmployeesPermissions.Employees.Create;
            UpdatePolicyName = SayaratechEmployeesPermissions.Employees.Edit;
            DeletePolicyName = SayaratechEmployeesPermissions.Employees.Delete;
        }
        public async Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync()
        {
            var authors = await _departmentRepository.GetListAsync();

            return new ListResultDto<DepartmentLookupDto>(
                ObjectMapper.Map<List<Department>, List<DepartmentLookupDto>>(authors)
            );
        }
        public override async Task<EmployeeDto> GetAsync(Guid id)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from employee in queryable
                        join department in await _departmentRepository.GetQueryableAsync() on employee.DepartmentId equals department.Id
                        where employee.Id == id
                        select new { employee, department };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Employee), id);
            }

            var EmployeeDto = ObjectMapper.Map<Employee, EmployeeDto>(queryResult.employee);
            EmployeeDto.DepartmentName = queryResult.department.Name;
            return EmployeeDto;
        }
        public override async Task<PagedResultDto<EmployeeDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from employee in queryable
                        join department in await _departmentRepository.GetQueryableAsync() on employee.DepartmentId equals department.Id
                        select new { employee, department };

            query = query
                .OrderBy(sort => NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var employeeDtos = queryResult.Select(x =>
            {
                var employeeDto = ObjectMapper.Map<Employee, EmployeeDto>(x.employee);
                employeeDto.DepartmentName = x.department.Name;
                return employeeDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<EmployeeDto>(
                totalCount,
                employeeDtos
            );
        }
        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"employee.{nameof(Employee.Name)}";
            }

            if (sorting.Contains("departmentName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "departmentName",
                    "department.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"employee.{sorting}";
        }
    }
}
