using ERPApplication.DomainLayer.Models.Organisation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.Data.Configurations
{
    internal class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder
                .HasMany<Employee>()
                .WithOne()
                .HasForeignKey(e=>e.UnitId);

            builder
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(e=>e.DepartmentId);
        }
    }
}
