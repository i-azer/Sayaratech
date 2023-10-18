// Ignore Spelling: Sayaratech

using Sayaratech.Entities;
using Sayaratech.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Sayaratech.Permissions
{
    public class EmployeesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var employeesGroup = context.AddGroup($"{SayaratechEmployeesPermissions.SayaratechGroup}_{nameof(Employee)}s", L("Permission:Employees:List"));

            var employeesGroupPermission = employeesGroup.AddPermission(SayaratechEmployeesPermissions.Employees.Default, L("Permission:Employees:List"));
            employeesGroupPermission.AddChild(SayaratechEmployeesPermissions.Employees.Create, L("Permission:Employees.Create"));
            employeesGroupPermission.AddChild(SayaratechEmployeesPermissions.Employees.Edit, L("Permission:Employees.Edit"));
            employeesGroupPermission.AddChild(SayaratechEmployeesPermissions.Employees.Delete, L("Permission:Employees.Delete"));
        }
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SayaratechResource>(name);
        }
    }
}
