using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NerdOlympics.Data.Migrations
{
    /// <inheritdoc />
    public partial class addRecordValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Records");
        }
    }
}
