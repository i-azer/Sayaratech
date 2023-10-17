// Ignore Spelling: Sayaratech

using Volo.Abp.Domain.Entities.Auditing;

namespace Sayaratech.Entities
{
    public class Department : FullAuditedEntity<Guid>
    {
        public required string Name { get; set; }
    }
}
