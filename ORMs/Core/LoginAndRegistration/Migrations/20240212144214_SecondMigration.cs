using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginAndRegistration.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginAndRegistration",
                table: "LoginAndRegistration");

            migrationBuilder.RenameTable(
                name: "LoginAndRegistration",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "LoginAndRegistration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginAndRegistration",
                table: "LoginAndRegistration",
                column: "UserId");
        }
    }
}
