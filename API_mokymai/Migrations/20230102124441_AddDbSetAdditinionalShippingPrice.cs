using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APImokymai.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSetAdditinionalShippingPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditinionalShippingPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DistanceKm = table.Column<int>(type: "INTEGER", nullable: false),
                    AdditionalPrice = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditinionalShippingPrices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditinionalShippingPrices");
        }
    }
}
