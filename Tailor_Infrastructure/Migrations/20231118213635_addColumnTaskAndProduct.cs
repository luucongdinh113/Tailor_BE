using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tailor_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addColumnTaskAndProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "CompleteDate",
            //    table: "Tasks",
            //    type: "datetime(6)",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "Percent",
            //    table: "Tasks",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "NoteCloth",
            //    table: "Products",
            //    type: "longtext",
            //    nullable: false)
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AddColumn<string>(
            //    name: "priceCloth",
            //    table: "Products",
            //    type: "longtext",
            //    nullable: false)
            //    .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "CompleteDate",
            //    table: "Tasks");

            //migrationBuilder.DropColumn(
            //    name: "Percent",
            //    table: "Tasks");

            //migrationBuilder.DropColumn(
            //    name: "NoteCloth",
            //    table: "Products");

            //migrationBuilder.DropColumn(
            //    name: "priceCloth",
            //    table: "Products");
        }
    }
}
