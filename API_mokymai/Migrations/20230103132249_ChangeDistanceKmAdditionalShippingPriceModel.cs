using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APImokymai.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDistanceKmAdditionalShippingPriceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DistanceKm",
                table: "AdditionalShippingPrices",
                newName: "DistanceKmId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalShippingPrices_DistanceKmId",
                table: "AdditionalShippingPrices",
                column: "DistanceKmId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AdditionalShippingPrices_DistanceKmId",
                table: "AdditionalShippingPrices");

            migrationBuilder.RenameColumn(
                name: "DistanceKmId",
                table: "AdditionalShippingPrices",
                newName: "DistanceKm");
        }
    }
}
