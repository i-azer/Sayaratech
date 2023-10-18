// Ignore Spelling: Sayaratech App

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sayaratech.Services.Contracts;
using Sayaratech.Services.Dtos.Employees;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Sayaratech.Pages.Employees
{
    public class CreateModalModel : EmployeesPageModel
    {
        [BindProperty]
        public CreateEmployeeViewModel Employee { get; set; }

        public List<SelectListItem> Departments { get; set; }


        private readonly IEmployeesAppService _employeesAppService;

        public CreateModalModel(IEmployeesAppService employeesAppService, IBlobAppService blobAppService)
        {
            _employeesAppService = employeesAppService;
        }

        public async Task OnGetAsync()
        {
            Employee = new CreateEmployeeViewModel();

            var authorLookup = await _employeesAppService.GetDepartmentLookupAsync();
            Departments = authorLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeesAppService.CreateAsync(
         ObjectMapper.Map<CreateEmployeeViewModel, CreateUpdateEmployeeDto>(Employee));
            return NoContent();
        }

        public class CreateEmployeeViewModel
        {
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
