using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APImokymai.Migrations
{
    /// <inheritdoc />
    public partial class AddShippingStatusToReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShippingStatus",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingStatus",
                table: "Reservations");
        }
    }
}
