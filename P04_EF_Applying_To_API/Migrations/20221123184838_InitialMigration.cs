using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P04EFApplyingToAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    SpiceLevel = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishId);
                });

            migrationBuilder.CreateTable(
                name: "RecipeItems",
                columns: table => new
                {
                    RecipeItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Calories = table.Column<double>(type: "REAL", nullable: false),
                    DishId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeItems", x => x.RecipeItemId);
                    table.ForeignKey(
                        name: "FK_RecipeItems_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItems_DishId",
                table: "RecipeItems",
                column: "DishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeItems");

            migrationBuilder.DropTable(
                name: "Dishes");
        }
    }
}
