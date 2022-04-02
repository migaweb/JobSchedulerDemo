using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSchedulerDemo.Persistence.Migrations
{
    public partial class StatusId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
