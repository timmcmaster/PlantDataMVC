using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantDataMVC.DbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Genus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LatinName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Effect = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceListType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kind = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleEvent",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SaleDate = table.Column<DateTime>(type: "date", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenusId = table.Column<int>(type: "int", nullable: false),
                    SpecificName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CommonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PropagationTime = table.Column<int>(type: "int", nullable: true),
                    Native = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Genus_GenusId",
                        column: x => x.GenusId,
                        principalSchema: "dbo",
                        principalTable: "Genus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductPrice",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceListTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    DateEffective = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrice", x => x.Id);
                    table.UniqueConstraint("AK_ProductPrice_ProductType_PriceListType_Date", x => new { x.PriceListTypeId, x.ProductTypeId, x.DateEffective });
                    table.ForeignKey(
                        name: "FK_ProductPrice_PriceListType_PriceListTypeId",
                        column: x => x.PriceListTypeId,
                        principalSchema: "dbo",
                        principalTable: "PriceListType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductPrice_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlantStock",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantStock_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlantStock_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalSchema: "dbo",
                        principalTable: "Species",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleEventStock",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleEventId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleEventStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleEventStock_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleEventStock_SaleEvent",
                        column: x => x.SaleEventId,
                        principalSchema: "dbo",
                        principalTable: "SaleEvent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SaleEventStock_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalSchema: "dbo",
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeedBatch",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    DateCollected = table.Column<DateTime>(type: "date", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    Emptied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedBatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeedBatch_Site_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "dbo",
                        principalTable: "Site",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeedBatch_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalSchema: "dbo",
                        principalTable: "Species",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeedTray",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeedBatchId = table.Column<int>(type: "int", nullable: false),
                    DatePlanted = table.Column<DateTime>(type: "date", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThrownOut = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedTray", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeedTray_SeedBatch_SeedBatchId",
                        column: x => x.SeedBatchId,
                        principalSchema: "dbo",
                        principalTable: "SeedBatch",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JournalEntry",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    JournalEntryTypeId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SeedTrayId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntry_JournalEntryType_JournalEntryTypeId",
                        column: x => x.JournalEntryTypeId,
                        principalSchema: "dbo",
                        principalTable: "JournalEntryType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JournalEntry_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntry_SeedTray_SeedTrayId",
                        column: x => x.SeedTrayId,
                        principalSchema: "dbo",
                        principalTable: "SeedTray",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JournalEntry_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalSchema: "dbo",
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_JournalEntryTypeId",
                schema: "dbo",
                table: "JournalEntry",
                column: "JournalEntryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_ProductTypeId",
                schema: "dbo",
                table: "JournalEntry",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_SeedTrayId",
                schema: "dbo",
                table: "JournalEntry",
                column: "SeedTrayId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_SpeciesId",
                schema: "dbo",
                table: "JournalEntry",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantStock_ProductTypeId",
                schema: "dbo",
                table: "PlantStock",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantStock_SpeciesId",
                schema: "dbo",
                table: "PlantStock",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_ProductTypeId",
                schema: "dbo",
                table: "ProductPrice",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleEventStock_ProductTypeId",
                schema: "dbo",
                table: "SaleEventStock",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleEventStock_SaleEventId",
                schema: "dbo",
                table: "SaleEventStock",
                column: "SaleEventId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleEventStock_SpeciesId",
                schema: "dbo",
                table: "SaleEventStock",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedBatch_SiteId",
                schema: "dbo",
                table: "SeedBatch",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedBatch_SpeciesId",
                schema: "dbo",
                table: "SeedBatch",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedTray_SeedBatchId",
                schema: "dbo",
                table: "SeedTray",
                column: "SeedBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_GenusId",
                schema: "dbo",
                table: "Species",
                column: "GenusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalEntry",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlantStock",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductPrice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SaleEventStock",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "JournalEntryType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SeedTray",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PriceListType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SaleEvent",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SeedBatch",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Site",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Species",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Genus",
                schema: "dbo");
        }
    }
}
