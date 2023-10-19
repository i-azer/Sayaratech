// Ignore Spelling: Sayaratech

using Volo.Abp.Domain.Entities.Auditing;

namespace Sayaratech.Entities
{
    public class Employee : FullAuditedEntity<Guid>
    {
        public required string Name { get; set; }
        public required string EmailAddress { get; set; }
        public required string Phone { get; set; }
        public required Guid DepartmentId { get; set; }
        public bool IsStillWorking { get; set; }
        public bool HasPhysicalFile { get; set; }
    }
}
