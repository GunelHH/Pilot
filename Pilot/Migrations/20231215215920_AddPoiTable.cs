using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pilot.Migrations
{
    /// <inheritdoc />
    public partial class AddPoiTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "POI",
                columns: table => new
                {
                    type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POI");
        }
    }
}
