using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NerdOlympics.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompetitionProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Competitions_CompetitionId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Users_UserId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_CompetitionId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_UserId",
                table: "Records");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Records",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClassificationType",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeasurementType",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassificationType",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "MeasurementType",
                table: "Competitions");

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Records",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Records_CompetitionId",
                table: "Records",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserId",
                table: "Records",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Competitions_CompetitionId",
                table: "Records",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Users_UserId",
                table: "Records",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
