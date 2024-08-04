using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caraspirator.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class userencrycode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 23, 16, 46, 38, 46, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 23, 16, 46, 38, 46, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 23, 16, 46, 38, 46, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 23, 16, 46, 38, 46, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 23, 16, 46, 38, 46, DateTimeKind.Local).AddTicks(785));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 12, 1, 53, 614, DateTimeKind.Local).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 12, 1, 53, 614, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 12, 1, 53, 614, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 12, 1, 53, 614, DateTimeKind.Local).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 11, 12, 1, 53, 614, DateTimeKind.Local).AddTicks(3086));
        }
    }
}
