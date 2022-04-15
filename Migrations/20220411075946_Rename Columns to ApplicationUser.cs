using Microsoft.EntityFrameworkCore.Migrations;

namespace FYP_AgroNepalTrade.Migrations
{
    public partial class RenameColumnstoApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutCount",
                schema: "Identity",
                table: "User",
                newName: "AboutContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutContent",
                schema: "Identity",
                table: "User",
                newName: "AboutCount");
        }
    }
}
