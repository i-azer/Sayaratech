using Sayaratech.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Sayaratech.Pages.Departments
{
    public class DepartmentsPageModel : AbpPageModel
    {
        public DepartmentsPageModel()
        {
            LocalizationResourceType = typeof(SayaratechResource);
        }
    }
}
