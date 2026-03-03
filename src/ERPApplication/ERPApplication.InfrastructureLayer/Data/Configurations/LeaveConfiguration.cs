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
    public class LeaveConfiguration : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
     
            builder
                .HasDiscriminator(l=>l.LeaveTypeId)
                .HasValue<SickLeave>(1)
                .HasValue<AnnualLeave>(2)
                .HasValue<FamilyResponsibilityLeave>(3)
                .HasValue<UnpaidLeave>(4);
            builder
                .HasOne(l => l.LeaveType)
                .WithMany()
                .HasForeignKey(l => l.LeaveTypeId);
        }
    }
}
