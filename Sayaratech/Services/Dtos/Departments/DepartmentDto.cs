// Ignore Spelling: Sayaratech Dtos Dto

using Volo.Abp.Application.Dtos;

namespace Sayaratech.Services.Dtos.Departments
{
    public class DepartmentDto : AuditedEntityDto<Guid>
    {
        public required string Name { get; set; }
    }
}
