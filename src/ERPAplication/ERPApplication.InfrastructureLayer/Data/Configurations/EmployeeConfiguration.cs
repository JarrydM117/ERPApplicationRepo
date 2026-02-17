using ERPApplication.DomainLayer.Models.Leave;
using ERPApplication.DomainLayer.Models.Organisation;
using ERPApplication.DomainLayer.Models.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.Data.Configurations
{
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.
                HasMany(e=>e.Roles)
                .WithMany()
                .UsingEntity("EmployeeeRoleBridge");

            builder
                .HasMany<Unit>()
                .WithOne()
                .HasForeignKey(e=>e.UnitHead)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder
                .HasOne<Employee>()
                .WithMany()
                .HasForeignKey(e => e.ReportingManagerId)
                .IsRequired(false);

            builder
                .HasOne<Department>()
                .WithOne(e=>e.Employee)
                .HasForeignKey<Department>(e => e.DepartmentHead)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder
                .HasMany<AllocatedTicket>()
                .WithOne(e=>e.Employee)
                .HasForeignKey(e=>e.EmployeeId)
                .IsRequired();

            builder
                .HasMany<EmployeeLeave>()
                .WithOne()
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired();

            builder
                .HasMany<EmployeeLeaveRequest>()
                .WithOne()
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired();

            builder
                .HasOne(e => e.EmployeeStatus)
                .WithMany()
                .HasForeignKey(e => e.EmployeeStatusId)
                .IsRequired();
        }
    }
}
