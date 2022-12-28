using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APImokymai.Migrations
{
    /// <inheritdoc />
    public partial class AddReservatonPropReservationStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReservationStatus",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationStatus",
                table: "Reservations");
        }
    }
}
