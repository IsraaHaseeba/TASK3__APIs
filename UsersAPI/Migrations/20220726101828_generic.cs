using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersAPI.Migrations
{
    public partial class generic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_UserID",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users2",
                table: "Users2",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Users2_UserID",
                table: "Post",
                column: "UserID",
                principalTable: "Users2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Users2_UserID",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users2",
                table: "Users2");

            migrationBuilder.RenameTable(
                name: "Users2",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_UserID",
                table: "Post",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
