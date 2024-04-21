using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updatedname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Postalcode",
                table: "Addresses",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Adressline_2",
                table: "Addresses",
                newName: "Addressline_2");

            migrationBuilder.RenameColumn(
                name: "Adressline_1",
                table: "Addresses",
                newName: "Addressline_1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Addresses",
                newName: "Postalcode");

            migrationBuilder.RenameColumn(
                name: "Addressline_2",
                table: "Addresses",
                newName: "Adressline_2");

            migrationBuilder.RenameColumn(
                name: "Addressline_1",
                table: "Addresses",
                newName: "Adressline_1");
        }
    }
}
