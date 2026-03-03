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
    internal class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder
                .HasOne(e => e.LeaveStatus)
                .WithMany()
                .HasForeignKey(e => e.LeaveStatusId)
                .IsRequired();
        }
    }
}
