using Microsoft.EntityFrameworkCore.Migrations;

namespace FYP_AgroNepalTrade.Migrations
{
    public partial class AddedUnitForPriceandUnitsForQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Units",
                schema: "Identity",
                table: "Product",
                newName: "UnitsForQuantity");

            migrationBuilder.AddColumn<string>(
                name: "UnitsForPrice",
                schema: "Identity",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitsForPrice",
                schema: "Identity",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "UnitsForQuantity",
                schema: "Identity",
                table: "Product",
                newName: "Units");
        }
    }
}
