using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APImokymai.Migrations
{
    /// <inheritdoc />
    public partial class AddMeasurePropBorrowingFeeRatio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BorrowingFeeRatio",
                table: "Measures",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowingFeeRatio",
                table: "Measures");
        }
    }
}
