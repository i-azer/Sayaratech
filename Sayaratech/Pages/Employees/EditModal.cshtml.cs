// Ignore Spelling: Sayaratech

using Microsoft.AspNetCore.Mvc;
using Sayaratech.Services.Contracts;
using Sayaratech.Services.Dtos.Employees;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sayaratech.Pages.Employees
{
    public class EditModalModel : EmployeesPageModel
    {
        [BindProperty]
        public EditEmployeeViewModel Employee { get; set; }

        public List<SelectListItem> Departments { get; set; }

        private readonly IEmployeesAppService _employeesAppService;

        public EditModalModel(IEmployeesAppService employeesAppService)
        {
            _employeesAppService = employeesAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var employeeDto = await _employeesAppService.GetAsync(id);
            Employee = ObjectMapper.Map<EmployeeDto, EditEmployeeViewModel>(employeeDto);

            var authorLookup = await _employeesAppService.GetDepartmentLookupAsync();
            Departments = authorLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeesAppService.UpdateAsync(
                    Employee.Id,
                    ObjectMapper.Map<EditEmployeeViewModel, CreateUpdateEmployeeDto>(Employee));

            return NoContent();
        }


        public class EditEmployeeViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [SelectItems(nameof(Departments))]
            [DisplayName("Department")]
            public Guid DepartmentId { get; set; }

            [Required]
            public string Name { get; set; }
            [Required]
            [EmailAddress]
            public string EmailAddress { get; set; }
            [Required]
            public string Phone { get; set; }
            public bool IsStillWorking { get; set; }
        }
    }
}
