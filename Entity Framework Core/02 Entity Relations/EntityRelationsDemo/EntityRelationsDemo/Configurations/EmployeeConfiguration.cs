using EntityRelationsDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityRelationsDemo.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                 .HasOne(x => x.Department)
                 .WithMany(x => x.Employees)
                 .HasForeignKey(x => x.Department);
        }
    }
}
