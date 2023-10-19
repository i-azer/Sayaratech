// Ignore Spelling: Dtos Sayaratech Dto

using Volo.Abp.Application.Dtos;

namespace Sayaratech.Services.Dtos.Employees
{
    public class EmployeeDto : AuditedEntityDto<Guid>
    {
        public required string Name { get; set; }
        public required string EmailAddress { get; set; }
        public required string Phone { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsStillWorking { get; set; }
        public bool HasPhysicalFile { get; set; }
    }
}
