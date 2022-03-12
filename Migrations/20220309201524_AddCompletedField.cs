using Microsoft.EntityFrameworkCore.Migrations;

namespace Jungle.Migrations
{
    public partial class AddCompletedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PurchaseCompleted",
                table: "Purchases",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseCompleted",
                table: "Purchases");
        }
    }
}
