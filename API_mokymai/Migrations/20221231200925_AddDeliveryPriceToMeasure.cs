using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APImokymai.Migrations
{
    /// <inheritdoc />
    public partial class AddDeliveryPriceToMeasure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryPrice",
                table: "Measures",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryPrice",
                table: "Measures");
        }
    }
}
