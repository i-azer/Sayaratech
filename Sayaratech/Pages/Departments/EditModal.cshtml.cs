// Ignore Spelling: Sayaratech

using Microsoft.AspNetCore.Mvc;
using Sayaratech.Services.Contracts;
using Sayaratech.Services.Dtos.Departments;

namespace Sayaratech.Pages.Departments
{
    public class EditModalModel : DepartmentsPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateDepartmentDto Department { get; set; }

        private readonly IDepartmentsAppService _departmentsAppService;

        public EditModalModel(IDepartmentsAppService departmentsAppService)
        {
            _departmentsAppService = departmentsAppService;
        }

        public async Task OnGetAsync()
        {
            var departmentDto = await _departmentsAppService.GetAsync(Id);
            Department = ObjectMapper.Map<DepartmentDto, CreateUpdateDepartmentDto>(departmentDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _departmentsAppService.UpdateAsync(Id, Department);
            return NoContent();
        }
    }
}
