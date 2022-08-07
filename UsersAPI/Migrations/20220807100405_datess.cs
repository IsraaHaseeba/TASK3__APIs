using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersAPI.Migrations
{
    public partial class datess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "createdBy",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "updatedBy",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "updatedBy",
                table: "Post");
        }
    }
}
