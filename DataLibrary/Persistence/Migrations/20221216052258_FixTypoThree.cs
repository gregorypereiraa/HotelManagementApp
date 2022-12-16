using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixTypoThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "RoomsId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomsId",
                table: "Bookings");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
