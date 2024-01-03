using EntityRelationsDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityRelationsDemo.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasOne(x => x.Address)
                .WithOne(x => x.Student)
                .HasForeignKey<Address>(x => x.StudentId);
        }
    }
}
