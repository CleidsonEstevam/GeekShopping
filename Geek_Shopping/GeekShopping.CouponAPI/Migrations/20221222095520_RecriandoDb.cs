using Microsoft.EntityFrameworkCore.Migrations;

namespace GeekShopping.CouponAPI.Migrations
{
    public partial class RecriandoDb : Migration
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
