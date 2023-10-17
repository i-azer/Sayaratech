using Microsoft.EntityFrameworkCore;
using Sayaratech.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sayaratech.Data.Configuration
{
    public static class DepartmentEntityDesigner
    {
        public static string DbScheme => "Sayaratech";
        public static void ConfigureDepartment(this ModelBuilder builder)
        {
            builder.Entity<Department>(options =>
            {
                options.ToTable($"{nameof(Department)}s", DbScheme);
                options.ConfigureByConvention();
            });
        }
    }
}
