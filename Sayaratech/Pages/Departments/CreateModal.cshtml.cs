// Ignore Spelling: Sayaratech App

using Microsoft.AspNetCore.Mvc;
using Sayaratech.Services.Contracts;
using Sayaratech.Services.Dtos.Departments;

namespace Sayaratech.Pages.Departments
{
    public class CreateModalModel : DepartmentsPageModel
    {
        [BindProperty]
        public CreateUpdateDepartmentDto Department { get; set; }

        private readonly IDepartmentsAppService _departmentsAppService;

        public CreateModalModel(IDepartmentsAppService departmentsAppService)
        {
            _departmentsAppService = departmentsAppService;
        }

        public void OnGet() => Department = new CreateUpdateDepartmentDto();

        public async Task<IActionResult> OnPostAsync()
        {
            await _departmentsAppService.CreateAsync(Department);
            return NoContent();
        }
    }
}
