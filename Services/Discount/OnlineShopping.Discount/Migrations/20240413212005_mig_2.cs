using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopping.Discount.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CounponId",
                table: "Coupons",
                newName: "CouponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CouponId",
                table: "Coupons",
                newName: "CounponId");
        }
    }
}
