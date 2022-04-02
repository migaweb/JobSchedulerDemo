using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSchedulerDemo.Persistence.Migrations
{
    public partial class JobIdNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                table: "ScheduledJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434), new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434), new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434), new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434), new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434), new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434), new DateTime(2022, 4, 2, 16, 57, 54, 141, DateTimeKind.Utc).AddTicks(1434) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                table: "ScheduledJobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847), new DateTime(2022, 4, 2, 16, 9, 56, 734, DateTimeKind.Utc).AddTicks(8847) });
        }
    }
}
