using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlanner.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceUser");

            migrationBuilder.DropTable(
                name: "AttendanceWedding");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_UserId",
                table: "Attendances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_WeddingId",
                table: "Attendances",
                column: "WeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Users_UserId",
                table: "Attendances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Weddings_WeddingId",
                table: "Attendances",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Users_UserId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Weddings_WeddingId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_UserId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_WeddingId",
                table: "Attendances");

            migrationBuilder.CreateTable(
                name: "AttendanceUser",
                columns: table => new
                {
                    AttendancesAttendanceId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceUser", x => new { x.AttendancesAttendanceId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_AttendanceUser_Attendances_AttendancesAttendanceId",
                        column: x => x.AttendancesAttendanceId,
                        principalTable: "Attendances",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AttendanceWedding",
                columns: table => new
                {
                    GuestsAttendanceId = table.Column<int>(type: "int", nullable: false),
                    WeddingsWeddingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceWedding", x => new { x.GuestsAttendanceId, x.WeddingsWeddingId });
                    table.ForeignKey(
                        name: "FK_AttendanceWedding_Attendances_GuestsAttendanceId",
                        column: x => x.GuestsAttendanceId,
                        principalTable: "Attendances",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceWedding_Weddings_WeddingsWeddingId",
                        column: x => x.WeddingsWeddingId,
                        principalTable: "Weddings",
                        principalColumn: "WeddingId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceUser_UsersUserId",
                table: "AttendanceUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceWedding_WeddingsWeddingId",
                table: "AttendanceWedding",
                column: "WeddingsWeddingId");
        }
    }
}
