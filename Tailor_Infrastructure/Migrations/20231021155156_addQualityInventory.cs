using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tailor_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addQualityInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Remain",
                table: "Inventories",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Inventories",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remain",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Inventories");
        }
    }
}
