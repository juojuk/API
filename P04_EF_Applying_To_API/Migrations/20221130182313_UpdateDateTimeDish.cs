using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P04EFApplyingToAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDateTimeDish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Dishes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 1,
                columns: new[] { "CreateDateTime", "UpdateDateTime" },
                values: new object[] { new DateTime(2022, 11, 30, 20, 23, 13, 125, DateTimeKind.Local).AddTicks(6657), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 2,
                columns: new[] { "CreateDateTime", "UpdateDateTime" },
                values: new object[] { new DateTime(2022, 11, 30, 20, 23, 13, 125, DateTimeKind.Local).AddTicks(6814), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 3,
                columns: new[] { "CreateDateTime", "UpdateDateTime" },
                values: new object[] { new DateTime(2022, 11, 30, 20, 23, 13, 125, DateTimeKind.Local).AddTicks(6867), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Dishes");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 23, 21, 58, 40, 952, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 23, 21, 58, 40, 952, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2022, 11, 23, 21, 58, 40, 952, DateTimeKind.Local).AddTicks(2484));
        }
    }
}
