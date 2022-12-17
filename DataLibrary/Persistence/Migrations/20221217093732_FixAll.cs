using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descritption",
                table: "RoomTypes",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "RoomTypes",
                newName: "Descritption");
        }
    }
}
