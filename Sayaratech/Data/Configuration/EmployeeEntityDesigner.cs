using Microsoft.EntityFrameworkCore;
using Sayaratech.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sayaratech.Data.Configuration
{
    public static class EmployeeEntityDesigner
    {
        public static string DbScheme => "Sayaratech";
        public static void ConfigureEmployee(this ModelBuilder builder)
        {
            builder.Entity<Employee>(options =>
            {
                options.ToTable($"{nameof(Employee)}s", DbScheme);
                options.ConfigureByConvention();
                options.HasOne<Department>().WithMany().HasForeignKey(emp => emp.DepartmentId).IsRequired();
            });
        }
    }
}
