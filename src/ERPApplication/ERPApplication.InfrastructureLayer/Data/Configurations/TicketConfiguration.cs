using ERPApplication.DomainLayer.Models.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.Data.Configurations
{

    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasMany<TicketAttachedFiles>()
                .WithOne()
                .HasForeignKey(f => f.TicketId)
                .IsRequired();

            builder
                .HasMany(t=>t.AllocatedTickets)
                .WithOne(t=>t.Ticket)
                .HasForeignKey(t=>t.TicketId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder
                .HasOne(e => e.TicketStatus)
                .WithMany()
                .HasForeignKey(e=>e.TicketStatusId)
                .IsRequired();
            builder
                .HasOne(t => t.Employee)
                .WithMany()
                .HasForeignKey(e=>e.EmployeeId)
                .IsRequired();

            builder
                .HasOne(t => t.SupportType)
                .WithMany()
                .HasForeignKey(t => t.SupportTypeId)
                .IsRequired();

        }
    }
}
