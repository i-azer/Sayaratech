using Volo.Abp.Application.Dtos;

namespace Sayaratech.Services.Dtos.Employees
{
    public class DepartmentLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
