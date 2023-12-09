using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tailor_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTableImagesProduct1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesProducts_ProductCategories_ProductCategoryId",
                table: "ImagesProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesProducts_Products_ProductId",
                table: "ImagesProducts");

            migrationBuilder.DropIndex(
                name: "IX_ImagesProducts_ProductCategoryId",
                table: "ImagesProducts");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "ImagesProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ImagesProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesProducts_Products_ProductId",
                table: "ImagesProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesProducts_Products_ProductId",
                table: "ImagesProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ImagesProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "ImagesProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ImagesProducts_ProductCategoryId",
                table: "ImagesProducts",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesProducts_ProductCategories_ProductCategoryId",
                table: "ImagesProducts",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesProducts_Products_ProductId",
                table: "ImagesProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
