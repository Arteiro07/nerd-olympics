using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NerdOlympics.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Users_UserId",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Competitions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Competitions",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Competitions_UserId",
                table: "Competitions",
                newName: "IX_Competitions_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Users_UserID",
                table: "Competitions",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Users_UserID",
                table: "Competitions");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Competitions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitions_UserID",
                table: "Competitions",
                newName: "IX_Competitions_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CreationUserId",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Users_UserId",
                table: "Competitions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
