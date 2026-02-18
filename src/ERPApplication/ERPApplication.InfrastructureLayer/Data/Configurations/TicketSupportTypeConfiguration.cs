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
    internal class TicketSupportTypeConfiguration : IEntityTypeConfiguration<TicketSupportType>
    {
        public void Configure(EntityTypeBuilder<TicketSupportType> builder)
        {
            builder
                .HasMany(t=>t.Units)
                .WithMany(t=>t.TicketSupportTypes)
                .UsingEntity("TicketSupportTypeUnitBridge");
        }
    }
}
