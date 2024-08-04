using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Caraspirator.Library.Migrations
{
    /// <inheritdoc />
    public partial class firstmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Category_Name = table.Column<string>(type: "longtext", nullable: false),
                    category_image = table.Column<string>(type: "longtext", nullable: false),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    slug = table.Column<string>(type: "longtext", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EspUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastLogin_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspUser", x => x.UserId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "category_id", "Category_Name", "category_image", "created_at", "is_active", "parent_id", "slug", "updated_at" },
                values: new object[,]
                {
                    { 1, "T-Shirt", "http://admin.queensudan.com//images//queenimage/categoryicon/Tshirtrealicon.png", new DateTime(2024, 2, 16, 21, 36, 40, 491, DateTimeKind.Local).AddTicks(3032), true, 0, "T-Shirt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Dresses", "http://admin.queensudan.com//images//queenimage/categoryicon/Dreesrealicon.png", new DateTime(2024, 2, 16, 21, 36, 40, 491, DateTimeKind.Local).AddTicks(3084), true, 0, "Dresses", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Blouses", "http://admin.queensudan.com//images//queenimage/categoryicon/blouserealicon.png", new DateTime(2024, 2, 16, 21, 36, 40, 491, DateTimeKind.Local).AddTicks(3088), true, 0, "Blouses", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Bottoms", "http://admin.queensudan.com//images//queenimage/categoryicon/blouserealicon.png", new DateTime(2024, 2, 16, 21, 36, 40, 491, DateTimeKind.Local).AddTicks(3092), true, 0, "Bottoms", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Beauty", "http://admin.queensudan.com//images//queenimage/categoryicon/Beauty.png", new DateTime(2024, 2, 16, 21, 36, 40, 491, DateTimeKind.Local).AddTicks(3096), true, 0, "Beauty", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Bag", "http://admin.queensudan.com//images//queenimage/categoryicon/bagrealicon.png", new DateTime(2024, 2, 16, 21, 36, 40, 491, DateTimeKind.Local).AddTicks(3100), true, 0, "Bag", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Jewellery", "http://admin.queensudan.com//images//queenimage/categoryicon/jewelleryrealicon.png", new DateTime(2024, 2, 16, 21, 36, 40, 491, DateTimeKind.Local).AddTicks(3103), true, 0, "Jewellery", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Shoes", "http://admin.queensudan.com//images//queenimage/categoryicon/shoesrealicon.png", new DateTime(2024, 2, 16, 21, 36, 40, 491, DateTimeKind.Local).AddTicks(3107), true, 0, "Shoes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "scarfs", "http://admin.queensudan.com//images//queenimage/categoryicon/categoryscrfus.png", new DateTime(2024, 2, 16, 21, 36, 40, 491, DateTimeKind.Local).AddTicks(3111), true, 0, "scarfs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Soft Clothes", "http://admin.queensudan.com//images//queenimage/categoryicon/SoftCategory.png", new DateTime(2024, 2, 16, 21, 36, 40, 491, DateTimeKind.Local).AddTicks(3115), true, 0, "Soft Clothes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "EspUser");
        }
    }
}
