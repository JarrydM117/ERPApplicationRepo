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
    internal class AllocatedTicketConfiguration : IEntityTypeConfiguration<AllocatedTicket>
    {
        public void Configure(EntityTypeBuilder<AllocatedTicket> builder)
        {
            
        }
    }
}
