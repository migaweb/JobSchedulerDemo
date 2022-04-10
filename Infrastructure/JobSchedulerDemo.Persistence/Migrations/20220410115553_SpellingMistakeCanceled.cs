using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSchedulerDemo.Persistence.Migrations
{
    public partial class SpellingMistakeCanceled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180), new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180), new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180), new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180), new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180), new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180), new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180), new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "LastModifiedDate", "Status" },
                values: new object[] { new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180), new DateTime(2022, 4, 10, 11, 55, 53, 583, DateTimeKind.Utc).AddTicks(1180), "Canceled" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "LastModifiedDate", "Status" },
                values: new object[] { new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), "Cenceled" });
        }
    }
}
