// Ignore Spelling: Sayaratech Dtos Dto

namespace Sayaratech.Services.Dtos.Employees
{
    public class CreateUpdateEmployeeDto
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public bool IsStillWorking { get; set; }
    }
}
