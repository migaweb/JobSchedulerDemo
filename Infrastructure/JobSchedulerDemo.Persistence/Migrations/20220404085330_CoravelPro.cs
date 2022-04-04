using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSchedulerDemo.Persistence.Migrations
{
    public partial class CoravelPro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coravel_JobHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeFullPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Failed = table.Column<bool>(type: "bit", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coravel_JobHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coravel_ScheduledJobHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeFullPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Failed = table.Column<bool>(type: "bit", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coravel_ScheduledJobHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coravel_ScheduledJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvocableFullPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CronExpression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreventOverlapping = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    TimeZoneInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coravel_ScheduledJobs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570), new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570), new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570), new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570), new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570), new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570), new DateTime(2022, 4, 4, 8, 53, 30, 27, DateTimeKind.Utc).AddTicks(570) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coravel_JobHistory");

            migrationBuilder.DropTable(
                name: "Coravel_ScheduledJobHistory");

            migrationBuilder.DropTable(
                name: "Coravel_ScheduledJobs");

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917), new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917), new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917), new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917), new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917), new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917), new DateTime(2022, 4, 2, 17, 11, 11, 566, DateTimeKind.Utc).AddTicks(7917) });
        }
    }
}
