using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgroNepalTrade.Migrations
{
    public partial class AddedUpdatedOntoBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "Identity",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "Identity",
                table: "Blogs");
        }
    }
}
