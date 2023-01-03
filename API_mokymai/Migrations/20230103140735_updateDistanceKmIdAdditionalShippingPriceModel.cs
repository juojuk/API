using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APImokymai.Migrations
{
    /// <inheritdoc />
    public partial class updateDistanceKmIdAdditionalShippingPriceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AdditionalShippingPrices_DistanceKmId",
                table: "AdditionalShippingPrices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalShippingPrices",
                table: "AdditionalShippingPrices",
                column: "DistanceKmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalShippingPrices",
                table: "AdditionalShippingPrices");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalShippingPrices_DistanceKmId",
                table: "AdditionalShippingPrices",
                column: "DistanceKmId",
                unique: true);
        }
    }
}
