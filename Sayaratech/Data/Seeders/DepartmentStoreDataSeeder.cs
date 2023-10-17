// Ignore Spelling: Sayaratech

using Sayaratech.Entities;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Sayaratech.Data.Seeders
{
    public class DepartmentStoreDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Department, Guid> _departmentRepository;
        public DepartmentStoreDataSeeder(IRepository<Department, Guid> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _departmentRepository.AnyAsync())
                return;

            var departments = new List<Department>
            { 
                new Department{ Name = "Information Technology" },
                new Department{ Name = "Finance" },
                new Department{ Name = "Compliance" }
            };

            await _departmentRepository.InsertManyAsync(departments);

        }
    }
}
