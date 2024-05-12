using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace detai_website_asp.Data.Migrations
{
    public partial class themmucsanpham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NhaCungCap",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NhaXuatBan",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TacGia",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NhaCungCap",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "NhaXuatBan",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "TacGia",
                table: "SanPham");
        }
    }
}
