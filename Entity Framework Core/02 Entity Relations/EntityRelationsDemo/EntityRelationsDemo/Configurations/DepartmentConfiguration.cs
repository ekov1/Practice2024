using EntityRelationsDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityRelationsDemo.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasMany(x => x.Employees)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DeparmentId);
        }
    }
}
