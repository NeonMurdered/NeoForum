using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeoForum.Migrations
{
    public partial class InitArticlesNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_SenderTwoId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_SenderTwoId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "SenderTwoId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Articles",
                newName: "Author");

            migrationBuilder.AddColumn<int>(
                name: "Categories",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Articles",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "SenderTwoId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SenderTwoId",
                table: "Articles",
                column: "SenderTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_SenderTwoId",
                table: "Articles",
                column: "SenderTwoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
