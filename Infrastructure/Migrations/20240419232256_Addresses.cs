using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Addresses",
                newName: "Postalcode");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Addresses",
                newName: "Adressline_1");

            migrationBuilder.AddColumn<string>(
                name: "Adressline_2",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adressline_2",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Postalcode",
                table: "Addresses",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Adressline_1",
                table: "Addresses",
                newName: "StreetName");
        }
    }
}
