using Microsoft.EntityFrameworkCore.Migrations;

namespace FYP_AgroNepalTrade.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_User_AuthorId",
                schema: "Identity",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                schema: "Identity",
                table: "Blogs",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AuthorId",
                schema: "Identity",
                table: "Blogs",
                newName: "IX_Blogs_CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_User_CreatorId",
                schema: "Identity",
                table: "Blogs",
                column: "CreatorId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_User_CreatorId",
                schema: "Identity",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                schema: "Identity",
                table: "Blogs",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CreatorId",
                schema: "Identity",
                table: "Blogs",
                newName: "IX_Blogs_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_User_AuthorId",
                schema: "Identity",
                table: "Blogs",
                column: "AuthorId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
