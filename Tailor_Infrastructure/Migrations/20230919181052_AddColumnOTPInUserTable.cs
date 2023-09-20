using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tailor_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnOTPInUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredOTP",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OTP",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiredOTP",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OTP",
                table: "Users");
        }
    }
}
