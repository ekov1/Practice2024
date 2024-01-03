using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsDemo.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> modelBuilder)
        {
            modelBuilder
               .ToTable("SpecialCar", "customSchema");

            modelBuilder
            .HasKey(x => x.CarId);

            modelBuilder
                .Property(c => c.Name)
                .HasColumnName("CarName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
            .IsRequired();

            modelBuilder
                .Ignore(c => c.InProjectOnly);

        }
    }
}
