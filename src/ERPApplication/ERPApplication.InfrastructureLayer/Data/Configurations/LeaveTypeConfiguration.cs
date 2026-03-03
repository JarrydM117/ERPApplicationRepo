using ERPApplication.DomainLayer.Models.Leave;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.Data.Configurations
{
    internal class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasMany<LeaveRequest>()
                .WithOne()
                .HasForeignKey(e=>e.LeaveTypeId)
                .IsRequired();
        }
    }
}
