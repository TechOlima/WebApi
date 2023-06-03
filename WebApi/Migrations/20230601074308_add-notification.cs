using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class addnotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailNotification",
                table: "Order",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SmsNotification",
                table: "Order",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailNotification",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SmsNotification",
                table: "Order");
        }
    }
}
