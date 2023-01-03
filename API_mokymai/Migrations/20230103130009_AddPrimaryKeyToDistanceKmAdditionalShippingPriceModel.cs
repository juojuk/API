using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APImokymai.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKeyToDistanceKmAdditionalShippingPriceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalShippingPrices",
                table: "AdditionalShippingPrices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdditionalShippingPrices");

            migrationBuilder.AlterColumn<int>(
                name: "DistanceKm",
                table: "AdditionalShippingPrices",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalShippingPrices",
                table: "AdditionalShippingPrices",
                column: "DistanceKm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalShippingPrices",
                table: "AdditionalShippingPrices");

            migrationBuilder.AlterColumn<int>(
                name: "DistanceKm",
                table: "AdditionalShippingPrices",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AdditionalShippingPrices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalShippingPrices",
                table: "AdditionalShippingPrices",
                column: "Id");
        }
    }
}
