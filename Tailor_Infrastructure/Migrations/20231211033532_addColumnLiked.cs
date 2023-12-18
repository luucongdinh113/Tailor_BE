using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tailor_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addColumnLiked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Liked",
                table: "User_Samples",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Liked",
                table: "User_Samples");
        }
    }
}
