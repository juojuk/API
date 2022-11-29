using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APImokymai.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Cover = table.Column<int>(type: "INTEGER", nullable: false),
                    PublishYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Cover", "PublishYear", "Title" },
                values: new object[,]
                {
                    { 1, "Spainito", 2, 1900, "Orange" },
                    { 2, "Spainito", 2, 1910, "Apple" },
                    { 3, "Africana", 2, 1920, "Banana" },
                    { 4, "Italiano", 2, 1930, "Grapes" },
                    { 5, "Germaner", 2, 1940, "Sausages" },
                    { 6, "Belaruska", 2, 1950, "Potatoes" },
                    { 7, "Belaruska", 2, 1960, "Tomato" },
                    { 8, "Lithuanis", 2, 1970, "Morkos" },
                    { 9, "Lithuanis", 2, 1980, "Onions" },
                    { 10, "Lithuanis", 2, 1990, "Aguonos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
