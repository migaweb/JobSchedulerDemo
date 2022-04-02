using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSchedulerDemo.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduledJobStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledJobStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scheduled = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Started = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Completed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledJobs_ScheduledJobStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ScheduledJobStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ScheduledJobStatuses",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Created" },
                    { 2, "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Scheduled" },
                    { 3, "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Running" },
                    { 4, "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Completed" },
                    { 5, "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Error" },
                    { 6, "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Initial Create", new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), "Rejected" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledJobs_StatusId",
                table: "ScheduledJobs",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledJobs");

            migrationBuilder.DropTable(
                name: "ScheduledJobStatuses");
        }
    }
}
