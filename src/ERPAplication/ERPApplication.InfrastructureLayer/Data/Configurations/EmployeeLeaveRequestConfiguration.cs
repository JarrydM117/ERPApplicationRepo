using ERPApplication.DomainLayer.Models.Leave;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.Data.Configurations
{
    internal class EmployeeLeaveRequestConfiguration : IEntityTypeConfiguration<EmployeeLeaveRequest>
    {
        public void Configure(EntityTypeBuilder<EmployeeLeaveRequest> builder)
        {
            builder
                .HasOne(e => e.LeaveStatus)
                .WithMany()
                .HasForeignKey(e => e.LeaveStatusId)
                .IsRequired();
        }
    }
}
