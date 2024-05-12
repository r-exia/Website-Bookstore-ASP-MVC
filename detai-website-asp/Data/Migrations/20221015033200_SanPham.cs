using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace detai_website_asp.Data.Migrations
{
    public partial class SanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl2",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl3",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl4",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl5",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl2",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "ImageUrl3",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "ImageUrl4",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "ImageUrl5",
                table: "SanPham");
        }
    }
}
