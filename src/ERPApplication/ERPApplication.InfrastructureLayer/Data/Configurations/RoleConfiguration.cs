using ERPApplication.DomainLayer.Models.Organisation;
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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasOne(e => e.Owner)
                .WithMany()
                .HasForeignKey(e => e.RoleOwner)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
