using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class addstdadress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Block",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddressStd",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Entrance",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Flat",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "House",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QC",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetWithType",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Block",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressStd",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Entrance",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Flat",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "House",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "QC",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StreetWithType",
                table: "Order");
        }
    }
}
