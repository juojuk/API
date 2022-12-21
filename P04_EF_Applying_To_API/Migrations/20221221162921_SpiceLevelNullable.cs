using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P04EFApplyingToAPI.Migrations
{
    /// <inheritdoc />
    public partial class SpiceLevelNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpiceLevel",
                table: "Dishes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2022, 12, 21, 18, 29, 21, 184, DateTimeKind.Local).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2022, 12, 21, 18, 29, 21, 184, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2022, 12, 21, 18, 29, 21, 184, DateTimeKind.Local).AddTicks(6605));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpiceLevel",
                table: "Dishes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2022, 12, 15, 19, 15, 50, 725, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2022, 12, 15, 19, 15, 50, 725, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2022, 12, 15, 19, 15, 50, 725, DateTimeKind.Local).AddTicks(6075));
        }
    }
}
