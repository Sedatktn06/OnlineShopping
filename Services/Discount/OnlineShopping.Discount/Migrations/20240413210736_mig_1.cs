using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopping.Discount.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CounponName",
                table: "Coupons",
                newName: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Coupons",
                newName: "CounponName");
        }
    }
}
