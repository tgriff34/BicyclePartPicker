using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicyclePartPicker.Migrations
{
    /// <inheritdoc />
    public partial class Version : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Bicycle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Bicycle");
        }
    }
}
