using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarterApp.Migrations
{
    public partial class HomeTextUniqueness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HomeText_Name",
                table: "HomeText",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HomeText_Name",
                table: "HomeText");
        }
    }
}
