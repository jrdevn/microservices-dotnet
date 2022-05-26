using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping.ProductAPI.Migrations
{
    public partial class AddProductOnDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
