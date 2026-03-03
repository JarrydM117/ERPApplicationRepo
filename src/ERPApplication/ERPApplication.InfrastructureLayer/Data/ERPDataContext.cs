using ERPApplication.DomainLayer.Models.Leave;
using ERPApplication.DomainLayer.Models.Organisation;
using ERPApplication.DomainLayer.Models.Tickets;
using ERPApplication.InfrastructureLayer.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.Data
{
    public class ERPDataContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Leave> Leave {  get; set; }
        public DbSet<AnnualLeave> AnnualLeave { get; set; }
        public DbSet<SickLeave> SickLeave {  get; set; }
        public DbSet<FamilyResponsibilityLeave> FamilyResponsibilityLeave { get; set; }
        public DbSet<UnpaidLeave> UnpaidLeave { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TicketAttachedFiles> TicketAttachedFiles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<AllocatedTicket> AllocatedTicket { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<TicketSupportType> TicketSupportTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<EmployeeOTP> OTP { get;set; }
        public ERPDataContext(DbContextOptions<ERPDataContext> options):base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new TicketConfiguration().Configure(builder.Entity<Ticket>());
            new EmployeeConfiguration().Configure(builder.Entity<Employee>());
            new LeaveRequestConfiguration().Configure(builder.Entity<LeaveRequest>());
            new LeaveTypeConfiguration().Configure(builder.Entity<LeaveType>());
            new TicketSupportTypeConfiguration().Configure(builder.Entity<TicketSupportType>());
            new UnitConfiguration().Configure(builder.Entity<Unit>());
            new RoleConfiguration().Configure(builder.Entity<Role>());
            new LeaveConfiguration().Configure(builder.Entity<Leave>());
        }
    }
}
