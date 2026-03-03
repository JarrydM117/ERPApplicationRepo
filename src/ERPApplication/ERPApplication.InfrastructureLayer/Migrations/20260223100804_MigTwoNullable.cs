using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPApplication.InfrastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class MigTwoNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllocatedTicket_Employee_EmployeeId",
                table: "AllocatedTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_AllocatedTicket_Ticket_TicketId",
                table: "AllocatedTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employee_DepartmentHead",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeStatus_EmployeeStatusId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_ReportingManagerId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Unit_UnitId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeeRoleBridge_Employee_EmployeeId",
                table: "EmployeeeRoleBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeave_Employee_EmployeeId",
                table: "EmployeeLeave");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeave_LeaveType_LeaveTypeId",
                table: "EmployeeLeave");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaveRequest_Employee_EmployeeId",
                table: "EmployeeLeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaveRequest_LeaveStatus_LeaveStatusId",
                table: "EmployeeLeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaveRequest_LeaveType_LeaveTypeId",
                table: "EmployeeLeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Employee_EmployeeId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketStatus_TicketStatusId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketSupportType_SupportTypeId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachedFiles_Ticket_TicketId",
                table: "TicketAttachedFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketSupportTypeUnitBridge_TicketSupportType_TicketSupportTypesId",
                table: "TicketSupportTypeUnitBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketSupportTypeUnitBridge_Unit_UnitsId",
                table: "TicketSupportTypeUnitBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Departments_DepartmentId",
                table: "Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Employee_UnitHead",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketSupportType",
                table: "TicketSupportType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveType",
                table: "LeaveType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeLeaveRequest",
                table: "EmployeeLeaveRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "TicketSupportType",
                newName: "TicketSupportTypes");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "LeaveType",
                newName: "LeaveTypes");

            migrationBuilder.RenameTable(
                name: "EmployeeLeaveRequest",
                newName: "EmployeeLeaveRequests");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_UnitHead",
                table: "Units",
                newName: "IX_Units_UnitHead");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_DepartmentId",
                table: "Units",
                newName: "IX_Units_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_TicketStatusId",
                table: "Tickets",
                newName: "IX_Tickets_TicketStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_SupportTypeId",
                table: "Tickets",
                newName: "IX_Tickets_SupportTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_EmployeeId",
                table: "Tickets",
                newName: "IX_Tickets_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeLeaveRequest_LeaveTypeId",
                table: "EmployeeLeaveRequests",
                newName: "IX_EmployeeLeaveRequests_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeLeaveRequest_LeaveStatusId",
                table: "EmployeeLeaveRequests",
                newName: "IX_EmployeeLeaveRequests_LeaveStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeLeaveRequest_EmployeeId",
                table: "EmployeeLeaveRequests",
                newName: "IX_EmployeeLeaveRequests_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_UnitId",
                table: "Employees",
                newName: "IX_Employees_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ReportingManagerId",
                table: "Employees",
                newName: "IX_Employees_ReportingManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_EmployeeStatusId",
                table: "Employees",
                newName: "IX_Employees_EmployeeStatusId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketSupportTypes",
                table: "TicketSupportTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveTypes",
                table: "LeaveTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeLeaveRequests",
                table: "EmployeeLeaveRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllocatedTicket_Employees_EmployeeId",
                table: "AllocatedTicket",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllocatedTicket_Tickets_TicketId",
                table: "AllocatedTicket",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_DepartmentHead",
                table: "Departments",
                column: "DepartmentHead",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeeRoleBridge_Employees_EmployeeId",
                table: "EmployeeeRoleBridge",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeave_Employees_EmployeeId",
                table: "EmployeeLeave",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeave_LeaveTypes_LeaveTypeId",
                table: "EmployeeLeave",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaveRequests_Employees_EmployeeId",
                table: "EmployeeLeaveRequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaveRequests_LeaveStatus_LeaveStatusId",
                table: "EmployeeLeaveRequests",
                column: "LeaveStatusId",
                principalTable: "LeaveStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaveRequests_LeaveTypes_LeaveTypeId",
                table: "EmployeeLeaveRequests",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeStatus_EmployeeStatusId",
                table: "Employees",
                column: "EmployeeStatusId",
                principalTable: "EmployeeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportingManagerId",
                table: "Employees",
                column: "ReportingManagerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Units_UnitId",
                table: "Employees",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachedFiles_Tickets_TicketId",
                table: "TicketAttachedFiles",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Employees_EmployeeId",
                table: "Tickets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketStatus_TicketStatusId",
                table: "Tickets",
                column: "TicketStatusId",
                principalTable: "TicketStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketSupportTypes_SupportTypeId",
                table: "Tickets",
                column: "SupportTypeId",
                principalTable: "TicketSupportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketSupportTypeUnitBridge_TicketSupportTypes_TicketSupportTypesId",
                table: "TicketSupportTypeUnitBridge",
                column: "TicketSupportTypesId",
                principalTable: "TicketSupportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketSupportTypeUnitBridge_Units_UnitsId",
                table: "TicketSupportTypeUnitBridge",
                column: "UnitsId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Departments_DepartmentId",
                table: "Units",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Employees_UnitHead",
                table: "Units",
                column: "UnitHead",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllocatedTicket_Employees_EmployeeId",
                table: "AllocatedTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_AllocatedTicket_Tickets_TicketId",
                table: "AllocatedTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_DepartmentHead",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeeRoleBridge_Employees_EmployeeId",
                table: "EmployeeeRoleBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeave_Employees_EmployeeId",
                table: "EmployeeLeave");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeave_LeaveTypes_LeaveTypeId",
                table: "EmployeeLeave");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaveRequests_Employees_EmployeeId",
                table: "EmployeeLeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaveRequests_LeaveStatus_LeaveStatusId",
                table: "EmployeeLeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaveRequests_LeaveTypes_LeaveTypeId",
                table: "EmployeeLeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeStatus_EmployeeStatusId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportingManagerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Units_UnitId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachedFiles_Tickets_TicketId",
                table: "TicketAttachedFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Employees_EmployeeId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketStatus_TicketStatusId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketSupportTypes_SupportTypeId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketSupportTypeUnitBridge_TicketSupportTypes_TicketSupportTypesId",
                table: "TicketSupportTypeUnitBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketSupportTypeUnitBridge_Units_UnitsId",
                table: "TicketSupportTypeUnitBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Departments_DepartmentId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Employees_UnitHead",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketSupportTypes",
                table: "TicketSupportTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveTypes",
                table: "LeaveTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeLeaveRequests",
                table: "EmployeeLeaveRequests");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.RenameTable(
                name: "TicketSupportTypes",
                newName: "TicketSupportType");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "LeaveTypes",
                newName: "LeaveType");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "EmployeeLeaveRequests",
                newName: "EmployeeLeaveRequest");

            migrationBuilder.RenameIndex(
                name: "IX_Units_UnitHead",
                table: "Unit",
                newName: "IX_Unit_UnitHead");

            migrationBuilder.RenameIndex(
                name: "IX_Units_DepartmentId",
                table: "Unit",
                newName: "IX_Unit_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketStatusId",
                table: "Ticket",
                newName: "IX_Ticket_TicketStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_SupportTypeId",
                table: "Ticket",
                newName: "IX_Ticket_SupportTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_EmployeeId",
                table: "Ticket",
                newName: "IX_Ticket_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UnitId",
                table: "Employee",
                newName: "IX_Employee_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ReportingManagerId",
                table: "Employee",
                newName: "IX_Employee_ReportingManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employee",
                newName: "IX_Employee_EmployeeStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeLeaveRequests_LeaveTypeId",
                table: "EmployeeLeaveRequest",
                newName: "IX_EmployeeLeaveRequest_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeLeaveRequests_LeaveStatusId",
                table: "EmployeeLeaveRequest",
                newName: "IX_EmployeeLeaveRequest_LeaveStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeLeaveRequests_EmployeeId",
                table: "EmployeeLeaveRequest",
                newName: "IX_EmployeeLeaveRequest_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Unit",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketSupportType",
                table: "TicketSupportType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveType",
                table: "LeaveType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeLeaveRequest",
                table: "EmployeeLeaveRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllocatedTicket_Employee_EmployeeId",
                table: "AllocatedTicket",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllocatedTicket_Ticket_TicketId",
                table: "AllocatedTicket",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employee_DepartmentHead",
                table: "Departments",
                column: "DepartmentHead",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeStatus_EmployeeStatusId",
                table: "Employee",
                column: "EmployeeStatusId",
                principalTable: "EmployeeStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_ReportingManagerId",
                table: "Employee",
                column: "ReportingManagerId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Unit_UnitId",
                table: "Employee",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeeRoleBridge_Employee_EmployeeId",
                table: "EmployeeeRoleBridge",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeave_Employee_EmployeeId",
                table: "EmployeeLeave",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeave_LeaveType_LeaveTypeId",
                table: "EmployeeLeave",
                column: "LeaveTypeId",
                principalTable: "LeaveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaveRequest_Employee_EmployeeId",
                table: "EmployeeLeaveRequest",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaveRequest_LeaveStatus_LeaveStatusId",
                table: "EmployeeLeaveRequest",
                column: "LeaveStatusId",
                principalTable: "LeaveStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaveRequest_LeaveType_LeaveTypeId",
                table: "EmployeeLeaveRequest",
                column: "LeaveTypeId",
                principalTable: "LeaveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Employee_EmployeeId",
                table: "Ticket",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketStatus_TicketStatusId",
                table: "Ticket",
                column: "TicketStatusId",
                principalTable: "TicketStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketSupportType_SupportTypeId",
                table: "Ticket",
                column: "SupportTypeId",
                principalTable: "TicketSupportType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachedFiles_Ticket_TicketId",
                table: "TicketAttachedFiles",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketSupportTypeUnitBridge_TicketSupportType_TicketSupportTypesId",
                table: "TicketSupportTypeUnitBridge",
                column: "TicketSupportTypesId",
                principalTable: "TicketSupportType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketSupportTypeUnitBridge_Unit_UnitsId",
                table: "TicketSupportTypeUnitBridge",
                column: "UnitsId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Departments_DepartmentId",
                table: "Unit",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Employee_UnitHead",
                table: "Unit",
                column: "UnitHead",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
