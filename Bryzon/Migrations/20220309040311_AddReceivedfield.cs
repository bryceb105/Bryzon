using Microsoft.EntityFrameworkCore.Migrations;

namespace Bryzon.Migrations
{
    public partial class AddReceivedfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PurchaseReceived",
                table: "Checkout",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseReceived",
                table: "Checkout");
        }
    }
}
