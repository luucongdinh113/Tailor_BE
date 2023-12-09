using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tailor_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addColumnIsUseColthInTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUseColth",
                table: "Tasks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUseColth",
                table: "Tasks");
        }
    }
}
