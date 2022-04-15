using Microsoft.EntityFrameworkCore.Migrations;

namespace FYP_AgroNepalTrade.Migrations
{
    public partial class AddingColumnstoApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutCount",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubHeader",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutCount",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SubHeader",
                schema: "Identity",
                table: "User");
        }
    }
}
