using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tailor_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MeasurementInformation_MeasurementId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "MeasurementInformation");

            migrationBuilder.DropIndex(
                name: "IX_Users_MeasurementId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MeasurementId",
                table: "Users");

            migrationBuilder.AddColumn<double>(
                name: "BottomCircumference",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CheckCircumference",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CuffCircumference",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HipCircumference",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InseamLength",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "KneeHeight",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NeckCircumference",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PantLegWidth",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PantLength",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ShirtLength",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ShoulderWidth",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SleeveLength",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ThighCircumference",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "UnderamCircumference",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WaistCircumference",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BottomCircumference",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CheckCircumference",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CuffCircumference",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HipCircumference",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InseamLength",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "KneeHeight",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NeckCircumference",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PantLegWidth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PantLength",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShirtLength",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShoulderWidth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SleeveLength",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ThighCircumference",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UnderamCircumference",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WaistCircumference",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "MeasurementId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MeasurementInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BottomCircumference = table.Column<double>(type: "double", nullable: false),
                    CheckCircumference = table.Column<double>(type: "double", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CuffCircumference = table.Column<double>(type: "double", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    HipCircumference = table.Column<double>(type: "double", nullable: false),
                    InseamLength = table.Column<double>(type: "double", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    KneeHeight = table.Column<double>(type: "double", nullable: false),
                    NeckCircumference = table.Column<double>(type: "double", nullable: false),
                    PantLegWidth = table.Column<double>(type: "double", nullable: false),
                    PantLength = table.Column<double>(type: "double", nullable: false),
                    ShirtLength = table.Column<double>(type: "double", nullable: false),
                    ShoulderWidth = table.Column<double>(type: "double", nullable: false),
                    SleeveLength = table.Column<double>(type: "double", nullable: false),
                    ThighCircumference = table.Column<double>(type: "double", nullable: false),
                    UnderamCircumference = table.Column<double>(type: "double", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    WaistCircumference = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementInformation", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MeasurementId",
                table: "Users",
                column: "MeasurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MeasurementInformation_MeasurementId",
                table: "Users",
                column: "MeasurementId",
                principalTable: "MeasurementInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
