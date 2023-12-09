using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tailor_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateNameColumnUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnderamCircumference",
                table: "Users",
                newName: "UnderarmCircumference");

            migrationBuilder.RenameColumn(
                name: "InseamLength",
                table: "Users",
                newName: "ButtCircumference");

            migrationBuilder.RenameColumn(
                name: "HipCircumference",
                table: "Users",
                newName: "ArmCircumference");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnderarmCircumference",
                table: "Users",
                newName: "UnderamCircumference");

            migrationBuilder.RenameColumn(
                name: "ButtCircumference",
                table: "Users",
                newName: "InseamLength");

            migrationBuilder.RenameColumn(
                name: "ArmCircumference",
                table: "Users",
                newName: "HipCircumference");
        }
    }
}
