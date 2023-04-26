using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantDataMVC.DbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AddBarcodeSKU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BarcodeSKU",
                schema: "dbo",
                table: "ProductPrice",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarcodeSKU",
                schema: "dbo",
                table: "ProductPrice");
        }
    }
}
