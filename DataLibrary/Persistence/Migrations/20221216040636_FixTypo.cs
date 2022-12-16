using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descritpion",
                table: "RoomTypes",
                newName: "Descritption");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descritption",
                table: "RoomTypes",
                newName: "Descritpion");
        }
    }
}
