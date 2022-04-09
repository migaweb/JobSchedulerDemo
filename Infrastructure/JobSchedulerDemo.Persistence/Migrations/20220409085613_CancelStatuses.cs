using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSchedulerDemo.Persistence.Migrations
{
    public partial class CancelStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "ScheduledJobStatuses",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "Status" },
                values: new object[,]
                {
                    { 7, "Initial Create", new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), "Initial Create", new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), "Cancelling" },
                    { 8, "Initial Create", new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), "Initial Create", new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250), "Cenceled" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926), new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926), new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926), new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926), new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926), new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "ScheduledJobStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926), new DateTime(2022, 4, 9, 7, 37, 57, 952, DateTimeKind.Utc).AddTicks(4926) });
        }
    }
}
