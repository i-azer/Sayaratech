// Ignore Spelling: Sayaratech

using Sayaratech.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Sayaratech.Permissions
{
    public class DepartmentsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var departmentsGroup = context.AddGroup(SayaratechDepartmentsPermissions.SayaratechGroup, L("Permission:List"));

            var departmentsGroupPermission = departmentsGroup.AddPermission(SayaratechDepartmentsPermissions.Departments.Default, L("Permission:List"));
            departmentsGroupPermission.AddChild(SayaratechDepartmentsPermissions.Departments.Create, L("Permission:Departments.Create"));
            departmentsGroupPermission.AddChild(SayaratechDepartmentsPermissions.Departments.Edit, L("Permission:Departments.Edit"));
            departmentsGroupPermission.AddChild(SayaratechDepartmentsPermissions.Departments.Delete, L("Permission:Departments.Delete"));
        }
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SayaratechResource>(name);
        }
    }
}
