using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace detai_website_asp.Data.Migrations
{
    public partial class themmota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "Productdetails",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Productdetails",
                table: "SanPham");

            
        }
    }
}
