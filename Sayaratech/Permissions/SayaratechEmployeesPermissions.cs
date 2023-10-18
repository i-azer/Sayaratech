// Ignore Spelling: Sayaratech

namespace Sayaratech.Permissions
{
    public class SayaratechEmployeesPermissions
    {
        public const string SayaratechGroup = "Sayaratech";

        public static class Employees
        {
            public const string Default = SayaratechGroup + ".Employees";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}
