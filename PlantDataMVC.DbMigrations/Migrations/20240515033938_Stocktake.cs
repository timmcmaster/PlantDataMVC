using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantDataMVC.DbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class Stocktake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocktake",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StocktakeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocktake", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StocktakeLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ExpectedQuantity = table.Column<int>(type: "int", nullable: false),
                    CountedQuantity = table.Column<int>(type: "int", nullable: false),
                    Applied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocktakeLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StocktakeLine_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StocktakeLine_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalSchema: "dbo",
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StocktakeLine_Stocktake_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "Stocktake",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StocktakeLine_HeaderId",
                table: "StocktakeLine",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_StocktakeLine_ProductTypeId",
                table: "StocktakeLine",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StocktakeLine_SpeciesId",
                table: "StocktakeLine",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StocktakeLine");

            migrationBuilder.DropTable(
                name: "Stocktake");
        }
    }
}
