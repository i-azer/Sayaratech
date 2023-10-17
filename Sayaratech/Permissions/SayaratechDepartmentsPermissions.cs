// Ignore Spelling: Sayaratech

namespace Sayaratech.Permissions
{
    public static class SayaratechDepartmentsPermissions
    {
        public const string SayaratechGroup = "Sayaratech";

        public static class Departments
        {
            public const string Default = SayaratechGroup + ".Departments";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}
