using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicyclePartPicker.Migrations
{
    /// <inheritdoc />
    public partial class AddListOfBBs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BicycleId",
                table: "BottomBracket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BottomBracket_BicycleId",
                table: "BottomBracket",
                column: "BicycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BottomBracket_Bicycle_BicycleId",
                table: "BottomBracket",
                column: "BicycleId",
                principalTable: "Bicycle",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BottomBracket_Bicycle_BicycleId",
                table: "BottomBracket");

            migrationBuilder.DropIndex(
                name: "IX_BottomBracket_BicycleId",
                table: "BottomBracket");

            migrationBuilder.DropColumn(
                name: "BicycleId",
                table: "BottomBracket");
        }
    }
}
