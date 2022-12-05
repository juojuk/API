using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarApiAiskinimas.Migrations
{
    /// <inheritdoc />
    public partial class INIT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mark = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlateNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    GearBox = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Fuel = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Fuel", "GearBox", "Mark", "Model", "PlateNumber", "Year" },
                values: new object[,]
                {
                    { 1, "Petrol", "Manual", "VW", "Golf", "AAA 001", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Electric", "Automatic", "Toyota", "Prius", "AAB 001", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Diesel", "Manual", "Opel", "Astra", "AAC 001", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Diesel", "Manual", "VW", "Passat", "AAA 002", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
