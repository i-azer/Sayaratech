// Ignore Spelling: Sayaratech

using Sayaratech.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Sayaratech.Pages.Employees
{
    public class EmployeesPageModel : AbpPageModel
    {
        public EmployeesPageModel()
        {
            LocalizationResourceType = typeof(SayaratechResource);
        }
    }
}
